using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : TileBehavor
{
    float smooth = 2f;
    public float target = 0;
    public float increment;
    float actual = 0;
    public float baseX;
    public float baseY;
    public float baseZ;
    public static int count = 0;
    public bool hasStarted = false;
    public bool zooming = false;
    public float alterX;
    public float alterY;
    public bool touchable = true;
    float zoomScale = 0.05f;
    float actualX;
    float actualY;
    Vector3 cap;
    
    void Start(){
//        if(PlayerPrefs.HasKey("TurnSmooth")){
//            smooth = PlayerPrefs.GetFloat("TurnSmooth");
//        }else{
//            PlayerPrefs.SetFloat("TurnSmooth",smooth);
//        }
        if(owner==null) owner = gameObject;
        //owner.transform.localRotation = Quaternion.Euler(baseX,baseY,actual+baseZ);
        if(isController){
            count = 0;
        }
        if(mother == null&&!isController){
            mother = owner.transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = owner.transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        alterX = owner.transform.localScale.x/3;
        alterY = owner.transform.localScale.y/3;
        cap = owner.transform.localScale;
        if(touchable)target = Random.Range(-6, 6)*increment;
        owner.transform.Rotate(0,0,target);
        actual = target;
        Join();
    }
    
    void FixedUpdate(){
        
//        if(PlayerPrefs.GetFloat("TurnSmooth")!=smooth){
//            smooth = PlayerPrefs.GetFloat("TurnSmooth");
//        }
        
        if(mother == null&&!isController){
            mother = owner.transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = owner.transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        
        if(isController){
            if(!hasStarted && count>0){ 
                GetComponent<SoundController>().PlayRotate();
                hasStarted = true;
            }
            if(hasStarted && count == 0){
                GetComponent<SoundController>().PauseRotate();
                hasStarted = false;
            }
            
            }else  if(zooming){
            bool temp = true;
            if(hasStarted){
                if(actualX < alterX){
                    actualX+=zoomScale;
                   owner.transform.localScale -= new Vector3(zoomScale, 0, 0);
                    temp = false;
                }
                if(actualY < alterY){
                    actualY+=zoomScale;
                   owner.transform.localScale -= new Vector3(0, zoomScale, 0);                    
                    temp = false;
                }
                }else{
                if(actualX > 0){
                    actualX-=zoomScale;
                   owner.transform.localScale += new Vector3(zoomScale, 0, 0);
                    temp = false;
                }
                if(actualY > 0){
                    actualY-=zoomScale;
                   owner.transform.localScale += new Vector3(0, zoomScale, 0);                    
                    temp = false;
                }
            }
            if(temp) zooming = false; 
        }else if(actual!=target){ 
            doTurn();
        }else if(cap != owner.transform.localScale){
            owner.transform.localScale = cap;
        }
    }
    
    void doTurn(){
        if(actual<target){
            actual += smooth;
            //owner.transform.localRotation = Quaternion.Euler(baseX,baseY,actual+baseZ);
            owner.transform.Rotate(0,0,smooth);
            if(actual == target){
                off();
                check();
                hasStarted = false;
                --count;
                zooming = true;
            }
            }else if(actual>target){
            actual -= smooth;
            //owner.transform.localRotation = Quaternion.Euler(baseX,baseY,actual+baseZ);
            owner.transform.Rotate(0,0,-smooth);
            if(actual == target){
                off(); 
                check();
                hasStarted = false;
                --count;
                zooming = true;
            }
        }
    }
    
    public virtual void OnMouseOver(){
        if(!touchable)return;
        if(getAct()){
            target += increment;
            if(!hasStarted){
                zooming = true;
                ++count;
                hasStarted = true;
            }
            }else if(getAlt()){
            target -= increment;
            if(!hasStarted){
                zooming = true;
                ++count;
                hasStarted = true;
            }
        }
    }
}
