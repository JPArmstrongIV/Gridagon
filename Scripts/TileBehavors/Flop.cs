using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flop : TileBehavor
{
    [SerializeField] private UnityEngine.Mesh[] MList;
    [SerializeField] private Quaternion[] RList;
    
    public GameObject target;
    
    int goal;
    static int count;
    private bool hasStarted;
    
    
    void Start(){
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
        Join();
    }
    
    void FixedUpdate(){
        if(mother == null&&!isController){
            mother = owner.transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = owner.transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        
        if(isController){
            if(!hasStarted && count>0){ 
                GetComponent<SoundController>().PlayTap();
                count--;
                hasStarted = true;
            }
            if(hasStarted && count == 0){
                GetComponent<SoundController>().PauseRotate();
                hasStarted = false;
            }
            
            }else if(hasStarted){
            target.GetComponent<MeshFilter>().mesh = MList[goal];
            target.GetComponent<MeshCollider>().sharedMesh = MList[goal];
            target.transform.localRotation = RList[goal];
            hasStarted = false;
            StartCoroutine(waiter());
        }
    }
    
    IEnumerator waiter(){
        yield return new WaitForSeconds(0.15f);
            off();
            check();
    }
    
    public virtual void OnMouseOver(){
        if(getAct()){
            goal++;
            if(!hasStarted){
                ++count;
                hasStarted = true;
            }
            }else if(getAlt()){
            goal--;
            if(!hasStarted){
                ++count;
                hasStarted = true;
            }
        }
        if(goal >= MList.Length){
            goal = 0;
            }else if(goal < 0){
            goal = MList.Length-1;
        }
    }
}
