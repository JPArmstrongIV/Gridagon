using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Func
{
    public Power me;
    public Power target;
    
    public override void doThing(){
        if(me.power==target.power) return;
        target.power = me.power;
        target.Light();
    }
    
    public override void offThing(){    
        if(me.power==target.power) return;
        target.power = me.power;
        target.Light();
    }
}
