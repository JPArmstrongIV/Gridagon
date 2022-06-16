using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameMenu : MonoBehaviour
{
    public UnityEngine.UI.Scrollbar TS;
    public UnityEngine.UI.Scrollbar SS;
    
    void Start(){
        if(PlayerPrefs.HasKey("TurnSmooth")){
            float turnsmooth = PlayerPrefs.GetFloat("TurnSmooth");
            float slidesmooth = PlayerPrefs.GetFloat("SlideSmooth");
            if(TS!=null)TS.SetValueWithoutNotify(turnsmooth/6-1/6);
            if(SS!=null)SS.SetValueWithoutNotify(slidesmooth*2-0.2f);
        }else{
            SetTurnSmooth(0.166f);
            SetSlideSmooth(0.8f);
        }
    }
    
    public void SetTurnSmooth (float smooth){
        smooth = smooth*6+1;
        PlayerPrefs.SetFloat("TurnSmooth", smooth);
        PlayerPrefs.Save();
    }
    
    public void SetSlideSmooth (float smooth){
        smooth = smooth/2+0.1f;
        PlayerPrefs.SetFloat("SlideSmooth", smooth);
        PlayerPrefs.Save();
    }
}
