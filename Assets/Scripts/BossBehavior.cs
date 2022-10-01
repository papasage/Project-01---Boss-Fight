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
    [SerializeField] bool movingTracking = false;
    [SerializeField] bool isEnraged = false;

    //variables that control the fire intervals
    float shotTimer = 0;
    bool fireAgain = false;
    [SerializeField] float coolDownSeconds = 1;

    //hookup to see the BrotherDied event
    [SerializeField] private Health _health;
    [SerializeField] Light _spotlight;

    //camera shake connection
    public CameraShake cameraShake;

    private void Update()
    {
        if (isEnraged == true)
        {
            if(coolDownSeconds >= .15f) 
            {
             _spotlight.intensity = Mathf.Lerp(_spotlight.intensity, _spotlight.intensity * 2.2f, Time.deltaTime);
            coolDownSeconds = Mathf.Lerp(coolDownSeconds, coolDownSeconds *.5f,   Time.deltaTime/1.5f);
            }
        }

        AutoFire(coolDownSeconds);
    }

    void FixedUpdate()
    {
        TurnTurret();

        //below are methods that I will eventually move to a state-controlled system

        if (movingTracking == true && playerTarget != null)
        {
            MoveTrackPlayer();
        }

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
        if (playerTarget != null){
            //establish the direction the cannon should turn to be facing the ray's hit
            Vector3 dir = new Vector3(playerTarget.position.x, cannonAimer.position.y, playerTarget.position.z);

            //GREEN Raycast is Pointing from camera plane to the mouse
            Debug.DrawLine(firepoint.transform.position, playerTarget.transform.position, Color.red);

            //Look in that direction!
            rbTurret.transform.LookAt(dir);
        }
    }
    void Shoot()
    {
        //Debug.Log("FIRE!");
        FindObjectOfType<AudioManager>().Play("projectile_fire");
        Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
    }
    void AutoFire(float _coolDown)
    {
        if (!fireAgain && playerTarget != null)
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
                if (isEnraged)
                {
                    cameraShake.recoil();
                }
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

    void MoveTrackPlayer()
    {
        //Debug.Log("PlayerX = " + playerTarget.position.x);
        //Vector3 playerTracking = new Vector3(playerTarget.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerTarget.position.x, Time.deltaTime), transform.position.y, transform.position.z) ;
    }

    public void OnBrotherDied()
    {
        movingLeft = false;
        movingRight = false;
        movingTracking = true;
        isEnraged = true;
    }


    private void OnEnable()
    {
        if (_health != null) { _health.BrotherDied += OnBrotherDied;}
        
    }
    private void OnDisable()
    {
        //if (_health != null) { _health.BrotherDied -= OnBrotherDied; }
    }
}
