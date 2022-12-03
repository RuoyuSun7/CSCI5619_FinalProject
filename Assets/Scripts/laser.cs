using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer rendo;
    public VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        rendo = gameObject.GetComponent<LineRenderer>();
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
            if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name == "door"){
                if(rayHit.collider.gameObject.transform.parent.transform.parent.transform.eulerAngles == new Vector3(0,0,0)){
                    rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,-90,0);
                }
                else{
                    rayHit.collider.gameObject.transform.parent.transform.parent.transform.Rotate(0,90,0);
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
            else if(OVRInput.Get(OVRInput.Button.Three) && rayHit.collider.gameObject.name != "Plane001"){
                rayHit.collider.gameObject.transform.position = endPos;
            }
        }

        rendo.SetPosition(0, targerPos);
        rendo.SetPosition(1, endPos);
    }
}
