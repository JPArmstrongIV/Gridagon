using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completed : MonoBehaviour
{
    public UnityEngine.Material undone;
    public UnityEngine.Material done;
    public string id;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(id)&&PlayerPrefs.GetInt(id)==1){
            GetComponent<MeshRenderer>().material = done;
        }else{
            GetComponent<MeshRenderer>().material = undone;
        }
    }
}
