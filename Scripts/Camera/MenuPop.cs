using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPop : MonoBehaviour
{
    private Stack<GameObject> MenuStack = new Stack<GameObject>();
    private GameObject view;
    private bool glassed;
    
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject SoundMenu;
    [SerializeField] private GameObject GraphicsMenu;
    [SerializeField] private GameObject GameMenu;
    [SerializeField] private GameObject LangMenu;
    
    [SerializeField] private GameObject Glass;
    
    readonly Vector3 OffStage = new Vector3(0,-10000000,0);
    readonly Vector3 Face = new Vector3(0,0,0);
    
    public void pauseMenu(){Push(PauseMenu);}
    public void settingsMenu(){Push(SettingsMenu);}
    public void soundMenu(){Push(SoundMenu);}
    public void graphicsMenu(){Push(GraphicsMenu);}
    public void gameMenu(){Push(GameMenu);}
    public void langMenu(){Push(LangMenu);}
    
    private void Push(GameObject fedIn){
        if(view!=null){
            view.transform.localPosition = OffStage;
            MenuStack.Push(view);
        }else{
            Glass.transform.localPosition = new Vector3(0,0,3);
        }
        view = fedIn;
        view.transform.localPosition = Face;
    }
    
    public void Back(){
        if(view!=null){
            view.transform.localPosition = OffStage;
            if(MenuStack.Count>0){
                view = MenuStack.Pop();
            }else view = null;
            if(view == null){
                Glass.transform.localPosition = new Vector3(0, 0, -10);
            }else view.transform.localPosition = Face;
        }
    }
}
