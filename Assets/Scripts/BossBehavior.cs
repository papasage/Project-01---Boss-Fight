using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody rbTurret; // The Rigidbody we will turn to make the Boss aim
    [SerializeField] Transform cannonAimer; // This is the transform that pulls the aiming in the player's direction
    [SerializeField] Transform playerTarget; // The player is the target

    [SerializeField] GameObject bullet; // The bullets this boss will fire
    [SerializeField] GameObject firepoint; // Where those bullets instantiate from

    // bools to check if the boss should be sliding left/right on the track
    [SerializeField] bool movingLeft = false;
    [SerializeField] bool movingRight = true;

    //variables that control the fire intervals
    float shotTimer = 0;
    bool fireAgain = false;
    [SerializeField] float coolDownSeconds = 1;

    private void Update()
    {
        AutoFire(coolDownSeconds);
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
    void AutoFire(float _coolDown)
    {
        if (!fireAgain)
        {
            //GUN COOLDOWN
            shotTimer += Time.deltaTime;

            //FIRE AT THE END OF THE COOLDOWN AND RESET
            if (shotTimer >= _coolDown)
            {
                fireAgain = true;
                Shoot();
                shotTimer = 0;
                fireAgain = false;
            }
        }
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
