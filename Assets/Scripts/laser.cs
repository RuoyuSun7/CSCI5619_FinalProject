using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer rendo;
    public VideoPlayer player;
    
    public Light ceilingLight;
    public Light Livingroom1;
    public Light Livingroom2;

    public ParticleSystem kitchen;
    public int iter;
    // Start is called before the first frame update
    void Start()
    {
        rendo = gameObject.GetComponent<LineRenderer>();
        kitchen = gameObject.GetComponent<ParticleSystem>();
        iter = 0;
        // var emission = kitchen.emission; // Stores the module in a local variable
        // emission.enabled = false; // Applies the new value directly to the Particle System
        // kitchen.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.RawButton.LHandTrigger)){
            enableLaser(transform.position, transform.forward, 5f);
            rendo.enabled = true;
        }
        else{
            rendo.enabled = false;
        }
    }


    void enableLaser(Vector3 targerPos, Vector3 direction, float length){

        Ray ray = new Ray(targerPos, direction);
        Vector3 endPos = targerPos + (direction) *length;

        if(Physics.Raycast(ray, out RaycastHit rayHit, length)){
            endPos = rayHit.point;
            Debug.Log(rayHit.collider.gameObject.name);
            if(rayHit.collider.gameObject.tag != "Wall"){
                 if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "CeilingLightButton"){
                    if(ceilingLight.enabled == true){
                        ceilingLight.enabled = false;
                    }
                    else{
                        ceilingLight.enabled = true;
                    }
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "bulb1"){
                    if(Livingroom1.enabled == true){
                        Livingroom1.enabled = false;
                    }
                    else{
                        Livingroom1.enabled = true;
                    }
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "bulb2"){
                    if(Livingroom2.enabled == true){
                        Livingroom2.enabled = false;
                    }
                    else{
                        Livingroom2.enabled = true;
                    }
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "door"){
                    if(rayHit.collider.gameObject.tag == "Outer"){
                        if(rayHit.collider.gameObject.transform.parent.transform.parent.transform.eulerAngles == new Vector3(0,0,0)){
                            rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,90,0);
                        }
                        else{
                            rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,-90,0);
                        }
                    }
                    else{
                         if(rayHit.collider.gameObject.transform.parent.transform.parent.transform.eulerAngles == new Vector3(0,0,0)){
                            rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,-90,0);
                        }
                        else{
                            rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,90,0);
                        }
                    }   
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "TVButton"){
                    if(player.isPlaying == true){
                        player.Pause();
                    }
                    else
                    {
                        player.Play();
                    }
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.tag == "drawer"){
                    if(rayHit.collider.gameObject.transform.eulerAngles == new Vector3(0,0,0)){
                        rayHit.collider.gameObject.transform.Rotate(0.1f,0,0);
                        //rayHit.collider.gameObject.transform.position = new Vector3(rayHit.collider.gameObject.transform.position.x+0.7f, rayHit.collider.gameObject.transform.position.y,rayHit.collider.gameObject.transform.position.z);
                        rayHit.collider.gameObject.transform.Translate(new Vector3(rayHit.collider.gameObject.transform.position.x, rayHit.collider.gameObject.transform.position.y,rayHit.collider.gameObject.transform.position.z+0.7f));
                    }
                    else{
                        rayHit.collider.gameObject.transform.Rotate(-0.1f,0,0);
                        //rayHit.collider.gameObject.transform.position = new Vector3(rayHit.collider.gameObject.transform.position.x-0.7f, rayHit.collider.gameObject.transform.position.y,rayHit.collider.gameObject.transform.position.z);
                        rayHit.collider.gameObject.transform.Translate(new Vector3(rayHit.collider.gameObject.transform.position.x, rayHit.collider.gameObject.transform.position.y,rayHit.collider.gameObject.transform.position.z-0.7f));
                    }
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "cover"){
                
                    
                        if(rayHit.collider.gameObject.transform.parent.transform.parent.transform.eulerAngles == new Vector3(0,0,0)){
                        rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(90,0,0);
                    }
                    else{
                        rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(-90,0,0);
                    }
                     
                }
                else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "WaterTap"){
                    if(kitchen.isPlaying == false){
                        kitchen.Play();
                    }
                    else{
                        kitchen.Stop();
                    }
                     
                }
                // else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name != "Plane001"){
                //     rayHit.collider.gameObject.transform.position = endPos;
                // }
            }
           
        }

        rendo.SetPosition(0, targerPos);
        rendo.SetPosition(1, endPos);
    }
}
