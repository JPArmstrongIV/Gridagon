using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : TileBehavor
{
    public float smooth = 0.6f;
    float target = 0;
    public float increment;
    float actual = 0;
    public int direction;
    public static int count = 0;
    bool hasStarted = false;
    public float max;
    public float min;
    public LineRenderer lr;
    public float lineStart;
    public static bool tap = false;
    int moveCount = 0;
    public bool rail = false;
    
    void Start(){
//        if(PlayerPrefs.HasKey("SlideSmooth")){
//            smooth = PlayerPrefs.GetFloat("SlideSmooth");
//        }else{
//            PlayerPrefs.SetFloat("SlideSmooth",smooth);
//        }
        if(owner==null) owner = gameObject;
        shift = Camera.main.GetComponent<ShiftKey>();
        if(isController){
            count = 0;
        }
        if(mother == null&&!isController){
            mother = owner.transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = owner.transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        Join();
    }
    
    bool clearWay(Vector3 input,int i){
        
        return true;
    }
    
    void FixedUpdate(){
        
//        if(PlayerPrefs.GetFloat("SlideSmooth")!=smooth){
//            smooth = PlayerPrefs.GetFloat("SlideSmooth");
//        }
        
        if(mother == null&&!isController){
            mother = owner.transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = owner.transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        
        if(isController){
            if(tap){
                Debug.Log("Tap");
                GetComponent<SoundController>().PlayTap();
                tap = false;
            }
            if(!hasStarted&&count>0){ 
                GetComponent<SoundController>().PlaySlide();
                hasStarted = true;
            }
            if(hasStarted && count == 0){
                GetComponent<SoundController>().PauseSlide();
                hasStarted = false;
            }
            
            }else if(moveCount>0){
            if(actual<target){
                alter(+1);
                }else if(actual>target){
                alter(-1);
            }
            }else{
            if(hasStarted){
                off();
                check();
                mother.pop = true;
                hasStarted = false;
                --count;
            }
        }
    }
    
    private void alter(int dir){
        moveCount--;
        bool track = true;
        if(direction==0){
            if(clearWay(new Vector3(1*dir,0,0),1)){
                owner.transform.localPosition += new Vector3(dir*smooth, 0, 0);
                }else{
                track = false;
                target = Mathf.Floor(actual/increment)*increment;
                moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            }
            }else if(direction==-1){            
            if(clearWay(new Vector3(0,-1*dir,0),2)){
                owner.transform.localPosition -= new Vector3(0, dir*smooth, 0);
                }else{
                track = false;
                target = Mathf.Floor(actual/increment)*increment;
                moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            }
            }else if(direction==-2){
            if(clearWay(new Vector3(-1*dir,0,0),2)){
                owner.transform.localPosition -= new Vector3(dir*smooth, 0, 0);
                }else{
                track = false;
                target = Mathf.Ceil(actual/increment)*increment;
                moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            }
            }else{
            if(clearWay(new Vector3(0,1*dir,0),1)){
                owner.transform.localPosition += new Vector3(0, dir*smooth, 0);
                }else{
                track = false;
                target = Mathf.Floor(actual/increment)*increment;
                moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            }
            if(target==max&&actual>max) moveCount = 0;
        }
        if(track){
            actual+=dir*smooth;
        }else{
            tap = true;
        }
        if(!rail)lr.SetPosition(1, new Vector3(lineStart-actual,0,0));
    }
    
    public void OnMouseOver(){
        if(getAct()){
            target += increment;
            moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            if(target > max) target = max;
            if(!hasStarted){
                ++count;
                hasStarted = true;
            }
            }else if(getAlt()){
            target -= increment;
            moveCount = (int)(Mathf.Abs(target-actual)/smooth);
            if(target < min){ 
                target = min;
                moveCount = (int)(Mathf.Abs(target-actual)/smooth);                
            }
            if(!hasStarted){
                ++count;
                hasStarted = true;
            }
        }
    }
}
