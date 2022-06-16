using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexLinker : Linker
{
    public override void Link()
    {
        List<GameObject> list = GetComponent<MotherPower>().powers;
        foreach(GameObject pole in list){
            var script = pole.GetComponent<Power>();
            script.Neighboors = new List<GameObject>();
            Collider[] hitColliders = Physics.OverlapSphere(pole.transform.position, 3.0f);
            Debug.Log(pole.transform.parent.gameObject.name);
            foreach (var hitCollider in hitColliders){
                Transform go = hitCollider.transform.parent.Find("Capsule");
                if(go != null&& go.gameObject!=pole){
                    script.Neighboors.Add(go.gameObject);
                }
            }
        }
    }
}
