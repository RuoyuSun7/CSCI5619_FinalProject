using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer rendo;
    
    // Start is called before the first frame update
    void Start()
    {
        rendo = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.RawButton.RHandTrigger)){
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

        }

        rendo.SetPosition(0, targerPos);
        rendo.SetPosition(1,endPos);
    }
}
