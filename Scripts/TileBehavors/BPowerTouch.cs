using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPowerTouch : Power
{
    public BridgePower[] childern;
    public MeshRenderer[] arts;
    
    override public void Charge(Power feed){
        power = feed.power;
        touch = feed.gameObject;
        Light();
    }
    
    // Update is called once per frame
    override public void Check()
    {
        if(power>0&&isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&!o.GetComponent<Power>().isSource&&o.GetComponent<Power>().power == 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        o.GetComponent<Power>().Charge(this);
                        chain.Add(o.GetComponent<Power>());
                        o.GetComponent<Power>().Check();
                    }
                }
            }
        }else if(isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&o.GetComponent<Power>().power > 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        Charge(o.GetComponent<Power>());
                        o.GetComponent<Power>().chain.Add(this);
                        deepCheck();
                        return;
                    }
                }
            }
        }
        
    }
    
    override public void deepCheck()
    {
        if(isAlive){
            foreach (GameObject o in Neighboors)if(o!=null&&o.GetComponent<Power>().isAlive&&!o.GetComponent<Power>().isSource&&o.GetComponent<Power>().power == 0){
                RaycastHit hit;
                Vector3 ray = o.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider == o.GetComponent<Collider>()) {
                        o.GetComponent<Power>().Charge(this);
                        chain.Add(o.GetComponent<Power>());
                        o.GetComponent<Power>().Check();
                    }
                }
            }
        }
    }
    
    public override void Off(int depth){
        if(!isSource&&isAlive&&power>0){
            if(touch!=null&&touch.GetComponent<Power>().power==0){
                depower();
                return;
            }else if(touch != null){
                RaycastHit hit;
                Vector3 ray = touch.transform.position - transform.position;
                if (Physics.Raycast(transform.position, ray, out hit)) {
                    if (hit.collider != touch.GetComponent<Collider>()){
                        depower();
                        return;
                    }
                }
            }
        }
        if(power!=0&&depth<1)foreach(Power p in chain){
            p.Off(depth++);
        }
    }
    
    public override void depower(){
        if(!isSource){
            if(isSink&&power>0) runner.offThing();
            power = 0;
            Light();
            foreach(Power p in chain){
                p.depower();
            }
            chain.Clear();
        }
    }
    
    public override void Light(){
        if(isSink&&power>0&&notTriggered){
            runner.doThing();
            notTriggered = false;
        }
        if(isAlive)
        parent.GetComponent<Color>().Light(power);
    if(power==0) 
    notTriggered = true;
    }
}
