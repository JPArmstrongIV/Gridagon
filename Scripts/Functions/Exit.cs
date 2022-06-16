using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Func
{
    public override void doThing(){
        Application.Quit();
    }
    
    public override void offThing(){
    }
}
