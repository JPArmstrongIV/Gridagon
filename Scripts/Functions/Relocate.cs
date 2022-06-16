using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocate : Func
{
    public GameObject cam;
    public float x;
    public float y;
    public float z;
    bool didThing = false;
    public bool locking = true;
    
    public override void doThing(){
    Debug.Log("Moved "+cam.name+" to (x,y,z):("+x+","+y+","+z+")");
        if(!didThing||!locking)cam.transform.localPosition = new Vector3(x,y,z);
        didThing = true;
    }
    
    public override void offThing(){
        didThing = false;
    }
}
