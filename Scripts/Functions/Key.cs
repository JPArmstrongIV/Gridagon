using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Func
{
    public Power target;
    
    public override void doThing(){
        target.isAlive = true;
    }
    
    public override void offThing(){
        target.isAlive = false;
        target.Off(0);
    }
}
