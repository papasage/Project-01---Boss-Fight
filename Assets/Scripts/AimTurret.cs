using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    [SerializeField] Rigidbody rbTurret;
    [SerializeField] Camera cam;
    [SerializeField] Transform cannonAimer;
    [SerializeField] GameObject crosshair;
    [SerializeField] float crosshairSpeed;
    [SerializeField] float adjustedCrosshairSpeed;

    void FixedUpdate()
    {
        RaycastMouse();
    }
  
    void RaycastMouse()
    {
        // set a ray to shoot from the mouse
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;

        //check to see if that ray calls true
        if(Physics.Raycast(mouseRay, out mouseHit))
        {
            Debug.DrawLine(mouseRay.origin, mouseHit.point);
            //feed the "hit" transform into the TurnTurret/Crosshair functions
            TurnTurret(mouseHit.point);
            //MoveCrosshair(mouseHit.point);
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

    void MoveCrosshair(Vector3 _hit)
    {
        Vector3 crossDir = new Vector3(_hit.x, cannonAimer.position.y, _hit.z);

        Ray playerToMouse = new Ray(cannonAimer.position, crossDir);

        RaycastHit distanceCheckHit;

        if (Physics.Raycast(playerToMouse, out distanceCheckHit))
        {
            adjustedCrosshairSpeed = Mathf.Log(crosshairSpeed - distanceCheckHit.distance);
            //set a visual object's transform to hit.point
            crosshair.transform.position = Vector3.MoveTowards(crosshair.transform.position, crossDir, adjustedCrosshairSpeed);
        }
    }
}
