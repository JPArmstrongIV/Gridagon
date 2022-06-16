using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSet : MonoBehaviour
{
    public Mesh[] list;
    public int ME;
    public GameObject MeshHolder;
    
    void Start(){
        setME(ME);
    }
    
    void setME(int newME){
        ME = newME;
        MeshHolder.GetComponent<MeshFilter>().mesh = list[ME];
        MeshHolder.GetComponent<MeshCollider>().sharedMesh = list[ME];
    }
}
