using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject referencePeople;
    public OVRInput.Controller Lcontroller;
    public OVRInput.Controller Head;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        float speed = 0.8f;
        //Debug.Log(input.x);
        //referencePeople.transform.position = referencePeople.transform.position + new Vector3(input.x*speed*Time.deltaTime, 0, input.y*speed*Time.deltaTime);
        referencePeople.transform.Translate(new Vector3(input.x*speed*Time.deltaTime, 0, input.y*speed*Time.deltaTime));
    }
}
