using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject hold;
    public bool dotate;
    
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        var go = Instantiate(objects[rand], transform.position, transform.rotation);
        if(dotate){
            var map = hold.GetComponent<Map>();
            go.GetComponent<Turn>().baseX = map.oddtateX;
            go.GetComponent<Turn>().baseY = map.oddtateY;
            go.GetComponent<Turn>().baseZ = map.oddtateZ;
        }
        go.transform.parent = hold.transform;
        go.GetComponent<Turn>().mother = hold.GetComponent<MotherPower>();
        Destroy(gameObject);
    }
}
