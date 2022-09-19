using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody rbTurret;
    [SerializeField] Camera cam;
    [SerializeField] Transform cannonAimer;
    [SerializeField] Transform playerTarget;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firepoint;

    [SerializeField] Transform rightStopper;
    [SerializeField] Transform leftStopper;

    [SerializeField] Vector3 velocity = Vector3.zero;
    [SerializeField] float smoothTime = 0.3f;

    bool movingLeft = false;
    bool movingRight = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        TurnTurret();

        //below are methods that I will eventually move to a state-controlled system
        if (movingRight == true)
        {
            MoveRight();
        }
        
        if (movingLeft == true)
        {
            MoveLeft();
        }
        
    }



    // _________________METHODS__________
    void TurnTurret()
    {
        //establish the direction the cannon should turn to be facing the ray's hit
        Vector3 dir = new Vector3(playerTarget.position.x, cannonAimer.position.y, playerTarget.position.z);

        //GREEN Raycast is Pointing from camera plane to the mouse
        Debug.DrawLine(firepoint.transform.position, playerTarget.transform.position, Color.red);

        //Look in that direction!
        rbTurret.transform.LookAt(dir);
    }

    void Shoot()
    {
        Debug.Log("FIRE!");
        FindObjectOfType<AudioManager>().Play("projectile_fire");
        Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
    }

    void MoveRight()
    {

        if (gameObject.transform.position.x <= 8f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime *4);
        }

        else
        {
            movingRight = false;
            movingLeft = true;
        }

        
    }
    void MoveLeft()
    {
        if (gameObject.transform.position.x >= -15f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 4);
        }

        else
        {
            movingLeft = false;
            movingRight = true; 
        }
    }
}
