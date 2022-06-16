using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenu : Func
{
    public int id;
    public MenuPop pop;
    bool didThing = false;
    
    public override void doThing(){
        if(!didThing)switch(id){
            case 0:
            pop.pauseMenu();
            break;
            case 1:
            pop.settingsMenu();
            break;
            case 2:
            pop.soundMenu();
            break;
            case 3:
            pop.graphicsMenu();
            break;
            case 4:
            pop.gameMenu();
            break;
            case 5:
            pop.langMenu();
            break;
        }
        didThing = true;
    }
    
    public override void offThing(){
        didThing = false;
    }
}
