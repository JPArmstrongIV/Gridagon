using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherHolder : MonoBehaviour
{
    public MotherPower hold;
    
    void Start(){
        if(hold == null){
            hold = transform.parent.gameObject.GetComponent<MotherPower>();
        }
    }
}
