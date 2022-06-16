using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTurn : Turn
{
    public Turn[] Effected;
    
    public override void OnMouseOver(){
        if(getAct()){
            target += increment;
            foreach(Turn t in Effected){
                t.target -= increment;
            }
            if(!hasStarted){
                zooming = true;
                ++count;
                hasStarted = true;
                foreach(Turn t in Effected)if(!t.hasStarted){
                    t.zooming = true;
                    ++count;
                    t.hasStarted = true;
                }
            }
            }else if(getAlt()){
            target -= increment;
            foreach(Turn t in Effected){
                t.target += increment;
            }
            if(!hasStarted){
                zooming = true;
                ++count;
                hasStarted = true;
                foreach(Turn t in Effected)if(!t.hasStarted){
                    t.zooming = true;
                    ++count;
                    t.hasStarted = true;
                }
            }
        }
    }
}
