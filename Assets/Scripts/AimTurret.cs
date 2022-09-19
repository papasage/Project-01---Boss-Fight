using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    [SerializeField] Rigidbody rbTurret;
    [SerializeField] Camera cam;
    [SerializeField] Transform cannonAimer;

    void FixedUpdate()
    {
        RaycastMouse();
    }
  
    void RaycastMouse()
    {
        // set a ray to shoot from the mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        //check to see if that ray calls true
        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);

            //feed the "hit" transform into the TurnTurret function
            TurnTurret(hit.point);
        }
    }
    void TurnTurret(Vector3 _hit)
    {
        //establish the direction the cannon should turn to be facing the ray's hit
        Vector3 dir = new Vector3(_hit.x, cannonAimer.position.y, _hit.z);

        //GREEN Raycast is Pointing from camera plane to the mouse
        Debug.DrawRay(cam.transform.position, dir - cam.transform.position, Color.green);
        
        //Look in that direction!
        rbTurret.transform.LookAt(dir);
    }
}
