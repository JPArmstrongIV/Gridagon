using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffCaller : Func
{
    public Func target;
    
    public override void doThing(){
        target.offThing();
    }
    
    public override void offThing(){
    }
}