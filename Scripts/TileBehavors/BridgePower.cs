using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePower : Power
{
    public BPowerTouch Father;
    
    override public void Charge(Power feed){
        Father.Charge(feed);
    }
    
    override public void Check()
    {
        Father.Check();
    }
    
    public override void Off(int depth){
        Father.Off(depth);
    }
    
    public override void depower(){
        Father.depower();
    }
    
    public override void Light(){
        Father.Light();
    }
}
