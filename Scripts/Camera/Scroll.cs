using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    public float rate;
    public GameObject target;
    
    
    void FixedUpdate()
    {
        target.transform.position += new Vector3(0, rate, 0);
    }
}
