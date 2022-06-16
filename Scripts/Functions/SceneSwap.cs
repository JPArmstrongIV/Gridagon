using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwap : Func
{
    public string target;
    int countdown = -1;
    
    void FixedUpdate(){
        if(countdown >0){
            countdown--;
        }else if(countdown ==0){
            var parameters = new LoadSceneParameters(LoadSceneMode.Single);
            Scene scene = SceneManager.LoadScene(target, parameters);
        }
    }
    
    public override void doThing(){
        countdown = 400;
    }
    
    public override void offThing(){
        countdown = -1;
    }
}
