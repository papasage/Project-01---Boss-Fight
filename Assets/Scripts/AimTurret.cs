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
    RaycastHit hit;
    //While Yellow and Green are pointing in the same location, they are hitting the floor in different locations because the mousePos is not limited on the y transform

    void Update()
    {
        RaycastMouse();

        
    }
    void TurnTurret(Vector3 _hit)
    {
        Vector3 dir = new Vector3(_hit.x, cannonAimer.position.y, _hit.z);

        Debug.DrawRay(cam.transform.position, dir - cam.transform.position, Color.green);      //GREEN Raycast is Pointing from camera plane to the mouse 

        rbTurret.transform.LookAt(dir);
    }

    void RaycastMouse()
    {
        
        ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
            TurnTurret(hit.point);
        }


    }


    //TO DO HERE. 9/18/2022 7pm
    //The cannon is not 100% accurate
    //the fire point is looking out at the direction of the end of mousePos. I need it to look at the transform that is stored when mousePos is a Physics.raycast
}
