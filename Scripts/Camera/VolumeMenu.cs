using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public UnityEngine.UI.Scrollbar MAV;
    public UnityEngine.UI.Scrollbar MUV;
    public UnityEngine.UI.Scrollbar SFV;
    
    void Start(){
        if(PlayerPrefs.HasKey("MasterVolume")){
            float mastervolume = PlayerPrefs.GetFloat("MasterVolume");
            audioMixer.SetFloat("MasterVolume", mastervolume);
            float musicvolume = PlayerPrefs.GetFloat("MusicVolume");
            audioMixer.SetFloat("MusicVolume", musicvolume);
            float sfxvolume = PlayerPrefs.GetFloat("SFXVolume");
            audioMixer.SetFloat("SFXVolume", sfxvolume);
            PlayerPrefs.Save();
            if(MAV!=null)MAV.SetValueWithoutNotify(mastervolume/80+1);
            if(MUV!=null)MUV.SetValueWithoutNotify(musicvolume/80+1);
            if(SFV!=null)SFV.SetValueWithoutNotify(sfxvolume/80+1);
        }else{
            SetVolume(1);
            SetMusicVolume(1);
            SetSFXVolume(1);
        }
    }
    
    public void SetVolume (float volume){
        volume = volume*80-80;
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
    
    public void SetMusicVolume (float volume){
        volume = volume*80-80;
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
    
    public void SetSFXVolume (float volume){
        volume = volume*80-80;
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}
