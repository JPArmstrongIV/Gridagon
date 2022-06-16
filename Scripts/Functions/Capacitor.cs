using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : Func
{    
    public Animator animator;
    public Power power;
    public MeshRenderer[] Cap;
    public Color c;
    
    public override void doThing(){
        power.isSource = true;
        foreach (MeshRenderer part in Cap){
            part.material = c.powers[power.power];
        }
        animator.SetBool("isCharged", true);
    }
    
    public override void offThing(){
    }
}
