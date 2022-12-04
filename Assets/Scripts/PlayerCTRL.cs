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
    private float yy;
    void Start()
    {
        yy = reference.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //reference.transform.position.y = yy;
    }

    void PlayerMove(){
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 direction = new Vector3(input.x, 0 ,input.y);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        //velocity.y -= g;
        reference.transform.Translate(velocity*Time.deltaTime/10.0f);
        reference.transform.position = new Vector3(reference.transform.position.x, yy, reference.transform.position.z) ;
    }
}
