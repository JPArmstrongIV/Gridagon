using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLink : MonoBehaviour
{
    public GameObject Link;
    public ParticleSystem target;
    
    void FixedUpdate(){
        var main = target.main;
        main.startColor = Link.GetComponent<Renderer>().material.color;
        
    }
    
}
