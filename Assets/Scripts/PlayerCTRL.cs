using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.01f;
    private float g = 10f;
    public OVRInput.Controller controller;
    public GameObject reference;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 direction = new Vector3(input.x, 0 ,input.y);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        //velocity.y -= g;
        reference.transform.Translate(velocity*Time.deltaTime/10.0f);
    }
}
