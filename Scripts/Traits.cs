using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    public UnityEngine.Color baseline;
    public SpriteRenderer touch;
    
    // Start is called before the first frame update
    void Start()
    {
        touch = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    public void OnMouseDown(){
        touch.color = baseline;
    }
}
