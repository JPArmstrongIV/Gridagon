using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLineLink : MonoBehaviour
{
    public GameObject Link;
    public GameObject Bond;
    public LineRenderer lr;
    public UnityEngine.Color endColor;
    
    void Start()
    {
        lr.endColor = endColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Bond==null||Link.GetComponent<Renderer>().material.color == Bond.GetComponent<Renderer>().material.color){
            UnityEngine.Color startColor = Link.GetComponent<Renderer>().material.color;
            
            lr.endColor = startColor;
            lr.startColor = startColor;
        }else{
            lr.endColor = endColor;
            lr.startColor = endColor;
        }
    }
}
