using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShiftKey : Func
{
    public bool shift;
    
    public override void doThing(){
        shift = !shift;
    }
    
    public override void offThing(){
    }
}
