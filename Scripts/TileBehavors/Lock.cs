using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{    
    public Animator animator;
    Power power;
    
    void Start(){
        power = GetComponent<Power>();
    }
    
    // Update is called once per frame
    void Update () {
        bool locked = !power.isAlive;

        animator.SetBool("Locked", locked);
    }
}
