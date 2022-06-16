using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiFunc : Func
{
    public Func[] funcs;
    
    public override void doThing(){
        foreach(Func func in funcs){
            func.doThing();
        }
    }
    
    public override void offThing(){
        foreach(Func func in funcs){
            func.offThing();
        }
    }
}
