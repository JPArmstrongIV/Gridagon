using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : Func
{
    public string id;
    
    public override void doThing(){
        PlayerPrefs.SetInt(id,1);
    }
    
    public override void offThing(){
    }
}
