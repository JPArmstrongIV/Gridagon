using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource Rotate;
    public AudioSource Slide;
    public AudioSource Lock;
    public AudioSource Tap;
    public AudioSource[] Music;
    public string[] Tracks;
    
    void Start(){
        if(PlayerPrefs.HasKey("Track")){
            int track = PlayerPrefs.GetInt("Track");
            PlayMusic(track);
        }else{
            PlayMusic(4);
        }
    }
    
    public void PlayTap(){
        Tap.time = 0f;
        Tap.Play();
    }
    
    public void PlayRotate(){
        Rotate.Play();
    }
    
    public void PauseRotate(){
        Rotate.Pause();
    }
    
    public void PlaySlide(){
        Slide.Play();
    }
    
    public void PauseSlide(){
        Slide.Pause();
    }
    
    public void PlayMusic(int i){
        foreach(AudioSource playbox in Music){
            playbox.Pause();
        }
        if(i>=0)Music[i].Play();
        PlayerPrefs.SetInt("Track",i);
        PlayerPrefs.Save();
    }
    
    public void NextTrack(){
        int track = PlayerPrefs.GetInt("Track");
        track++;
        if(track >= Music.Length) track = -1;
        PlayMusic(track);
    }
    
    public void PastTrack(){
        int track = PlayerPrefs.GetInt("Track");
        track--;
        if(track < -1) track = Music.Length-1;
        PlayMusic(track);
    }
    
    public string ReadTrack(){
        int track = PlayerPrefs.GetInt("Track");
        return Tracks[track+1];
    }
}
