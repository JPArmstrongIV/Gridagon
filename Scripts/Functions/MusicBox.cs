using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicBox : Func
{
    public int target;
    public SoundController run;
    
    public override void doThing(){
        run.PlayMusic(target);
    }
    
    public override void offThing(){
    }
}
