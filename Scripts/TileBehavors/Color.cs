using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    public UnityEngine.Material[] powers;
    public int state = 0;
    public GameObject fill;
    bool isO = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(state<0){
            state = Random.Range(1, powers.Length);
            isO = true;
        }
        RePaint();
    }
    
    public void OnMouseOver(){
        RePaint();
    }

    void RePaint()
    {
        fill.GetComponent<MeshRenderer> ().material = powers[state];
    }
    
    public void Light(int power){
        if(!isO){
            state = power;
            RePaint();
        }
    }
}
