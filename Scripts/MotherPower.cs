using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherPower : MonoBehaviour
{
    public List<GameObject> powers;
    public int powerSources = 1;
    public bool gen = false;
    public bool pop = false;
    public int count = 200;
    private int resetcount = 400;
    int setCount;
    
    void Start(){
        Debug.Log("Heading");
        setCount = count;
        count = -count*10;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gen){
            int i = 0;
            foreach (Transform child in transform) {
                powers[i++] = child.Find("Capsule").gameObject;
            }
            for(int index = 0;index < powerSources;){
                int target = Random.Range(0, powers.Count);
                if(!powers[target].GetComponent<Power>().isSource&&powers[target].GetComponent<Power>().isAlive){
                    powers[target].GetComponent<Power>().power = ++index;
                    powers[target].GetComponent<Power>().isSource = true;
                    powers[target].GetComponent<Power>().Light();
                }
            }
            gen = true;
            GetComponent<Linker>().Link();
        }
        if(count<=0){
            if(powers!=null)
            foreach(GameObject p in powers) if(p!=null) p.GetComponent<Power>().Check();
            if(powers!=null)
            foreach(GameObject p in powers) if(p!=null) p.GetComponent<Power>().Check();
            count += setCount;
        }else count--;
        if(pop){
            foreach(GameObject p in powers)if(p!=null){
                p.GetComponent<Power>().Off(1);
            }
            count = -setCount*2;
            pop = false;
        }
        if(resetcount==0){
            foreach(GameObject p in powers)if(p!=null){
                p.GetComponent<Power>().Off(1);
            }
            foreach(GameObject p in powers) if(p!=null) p.GetComponent<Power>().Check();
        } 
        if(resetcount!<0)resetcount--;
    }
    
    public void Switch(){
        foreach(GameObject p in powers)if(p!=null){
            p.GetComponent<Power>().Off(1);
            p.GetComponent<Power>().Check();
        }
        count = -setCount*10;
    }
}
