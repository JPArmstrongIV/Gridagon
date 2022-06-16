using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : TileBehavor
{
    public static List<GameObject> core = new List<GameObject>();
    public int groupIndex;
    public bool isHeld;
    
    void Start(){
        shift = Camera.main.GetComponent<ShiftKey>();
        if(isHeld){
            StartCoroutine(push());
        }
        if(mother == null){
            mother = transform.parent.gameObject.GetComponent<MotherPower>();
            if(mother == null){
                mother = transform.parent.gameObject.GetComponent<MotherHolder>().hold;
            }
        }
        Join();
    }
    
    IEnumerator push(){
        yield return new WaitUntil(() => core.Count==groupIndex);
        core.Add(gameObject);
    }
    
    public void OnMouseOver(){
        if(getAct()){
            Mesh tempMF = GetComponent<MeshFilter>().mesh;
            Mesh tempMC = GetComponent<MeshCollider>().sharedMesh;
            var tempR = transform.rotation;
            
            GetComponent<MeshFilter>().mesh = core[groupIndex].GetComponent<MeshFilter>().mesh;
            GetComponent<MeshCollider>().sharedMesh = core[groupIndex].GetComponent<MeshCollider>().sharedMesh;
            core[groupIndex].GetComponent<MeshFilter>().mesh = tempMF;
            core[groupIndex].GetComponent<MeshCollider>().sharedMesh = tempMC;
            transform.rotation = core[groupIndex].transform.rotation;
            core[groupIndex].transform.rotation = tempR;
            
            mother.Switch();
        }
    }
}
