using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavor : MonoBehaviour
{
    public MotherPower mother;
    public List<GameObject> powers = new List<GameObject>();
    public static bool shift;
    public bool isController = false;
    public GameObject owner;
    
    void Start()
    {
        shift = Camera.main.GetComponent<ShiftKey>();
        if(mother == null&&!isController){
            mother = transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        Join();
    }
 
    public void Join(){
        if(mother!=null&&powers!=null)mother.powers.AddRange(powers);
    }
    
    public bool getAct(){
        if(!inAlt()){
            return Input.GetButtonDown("Act");
        }else{
            return Input.GetButtonDown("AltAct");
        }
    }
    
    public void off(){
        foreach(GameObject go in powers){
            go.GetComponent<Power>().Off(0);
        }
    }
    
    public void check(){
        foreach(GameObject go in powers){
            go.GetComponent<Power>().Check();
        }
    }
    
    public bool getAlt(){
        if(!inAlt()){
            return Input.GetButtonDown("AltAct");
        }else{
            return Input.GetButtonDown("Act");
        }
    }
    
    bool inAlt(){
        return shift;
    }
    
    public static void Shift(){
        shift = !shift;
    }
}
