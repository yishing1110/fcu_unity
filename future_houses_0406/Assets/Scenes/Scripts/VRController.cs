using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRController : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 0.01f;
    public SteamVR_Action_Vector2 input;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //transform.position += speed * Time.deltaTime * new Vector3(input.axis.x, 0, input.axis.y);

        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        
        Vector3 movement = speed * Time.deltaTime * new Vector3(input.axis.x, 0, input.axis.y) - new Vector3(0, 9.81f, 0) * Time.deltaTime; 
        
        characterController.Move(movement);

        //Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        //transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        //characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
    }
}
