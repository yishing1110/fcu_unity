using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRController1 : MonoBehaviour
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

        if (input.axis.magnitude > 0.1f) { // so it doesn't interfere with teleportation
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        }
    }
}
