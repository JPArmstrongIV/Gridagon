using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class DynamicText : MonoBehaviour
{
    [SerializeField] private LocalizedString stringRef = new LocalizedString() { TableReference = "Menus", TableEntryReference = "id_Mute" };
    [SerializeField] private SoundController SC;
    public Text field;
    public string ID;
    
    void Start(){
        Read();
    }
    
    public void Read(){
        ID = SC.ReadTrack();
        stringRef.TableEntryReference = ID;
        UpdateString(stringRef.GetLocalizedString());
    }
    
    void OnEnable()
    {
        stringRef.StringChanged += UpdateString;
    }

    void OnDisable()
    {
        stringRef.StringChanged -= UpdateString;
    }
    
    void UpdateString(string s)
    {
        field.text = s;
    }
}
