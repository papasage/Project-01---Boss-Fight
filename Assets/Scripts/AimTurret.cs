using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    [SerializeField] Rigidbody rbTurret;
    [SerializeField] Camera cam;
    [SerializeField] Transform cannonAimer;
    [SerializeField] float mousePosZ = 100f;
    Ray ray;
    Vector3 mousePos;
    //While Yellow and Green are pointing in the same location, they are hitting the floor in different locations because the mousePos is not limited on the y transform

    void Update()
    {
        RaycastMouse();
        TurnTurret();

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(cannonAimer.position, forward, Color.red);                                    //RED Raycast is the Tank's "Laser Sight"
        Debug.DrawRay(cam.transform.position, mousePos - cam.transform.position, Color.green);      //GREEN Raycast is Pointing from camera plane to the mouse 
    }
    void TurnTurret()
    {
        Vector3 dir = new Vector3(mousePos.x, cannonAimer.position.y, mousePos.z);
        Debug.DrawRay(cannonAimer.position, dir, Color.yellow);                                     //YELLOW Raycast is from Cannon's tip to mouse
        rbTurret.transform.LookAt(dir);
    }

    void RaycastMouse()
    {

        //Physics.Raycast

        mousePos = Input.mousePosition;
        mousePos.z = mousePosZ;
        mousePos = cam.ScreenToWorldPoint(mousePos);
    }


    //TO DO HERE. 9/18/2022 7pm
    //The cannon is not 100% accurate
    //the fire point is looking out at the direction of the end of mousePos. I need it to look at the transform that is stored when mousePos is a Physics.raycast
}
