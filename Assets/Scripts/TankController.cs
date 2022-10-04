using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Rigidbody rbMain = null;

    [SerializeField] float maxSpeed = .25f;
    [SerializeField] float turnSpeed = 2f;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firepoint;

    [SerializeField] Material bulletColor;
    [SerializeField] Color normBulletColor;
    [SerializeField] Color normBulletEmission;
    [SerializeField] Color powerBulletColor;
    [SerializeField] Color powerBulletEmission;
    bool poweredUp = false;

    //variables that control the fire intervals
    float shotTimer = 1;
    bool fireAgain = false;
    [SerializeField] float coolDownSeconds = 1;
    [SerializeField] float coolDownSecondsPower = .3f;
    [SerializeField] ParticleSystem powerParticle;

    //camera shake connection
    public CameraShake cameraShake;
    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeMagnitude;

    //music change connection for powerup
    [SerializeField] MusicChanger _music;
    [SerializeField] Light _spotlight;
    [SerializeField] Light _cannonSpotlight;

    //Character Portrait Stuff
    [SerializeField] CharacterPortraitController _portrait;

    //Cursor
    [SerializeField] CursorManager _cursorManager;

    private void Start()
    {
        bulletColor.SetColor("_Color", normBulletColor);
        bulletColor.SetColor("_EmissionColor", normBulletEmission);
    }
    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
    }

    private void Update()
    {
        AutoFire(coolDownSeconds);

        if (poweredUp == true)
        {
            _cannonSpotlight.color = Color.blue;
            _cannonSpotlight.intensity = Mathf.Lerp(_cannonSpotlight.intensity, _cannonSpotlight.intensity * 1.1f, Time.deltaTime);
        }
    }

    public void MoveTank()
    {
        float moveAmountThisFrame = Input.GetAxis("Vertical") * maxSpeed;
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;

        rbMain.MovePosition(rbMain.position + moveOffset);

    }
    public void TurnTank()
    {
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);

        rbMain.MoveRotation(rbMain.rotation * turnOffset);

    }
    void Shoot()
    {
        //Debug.Log("FIRE!");
        _portrait.StartCoroutine("Firing");
        cameraShake.recoil();
        _cursorManager.cursorFeedback("Fire");
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
            }
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
            shotTimer = 0;
            fireAgain = false;
        }

    }

   public void PowerUp(float cooldownBuff)
    {
        poweredUp = true;
        _cursorManager.cursorFeedback("PoweredUp");
        FindObjectOfType<AudioManager>().Play("powerup");
        coolDownSeconds = cooldownBuff;
        bulletColor.SetColor("_Color", powerBulletColor);
        bulletColor.SetColor("_EmissionColor", powerBulletEmission);
        powerParticle.Play();
        _music.Phase3();
        int t = 0;
        if (t <=60 )
        {
            t++;
            _spotlight.intensity = Mathf.Lerp(_spotlight.intensity, _spotlight.intensity * 10, Time.deltaTime);
        }
    }


    //CLEANUP CREW
    // How can I refactor this to follow DRY?

    private void OnDisable()
    {
        bulletColor.SetColor("_Color", normBulletColor);
        bulletColor.SetColor("_EmissionColor", normBulletEmission);
    }

    private void OnDestroy()
    {
        bulletColor.SetColor("_Color", normBulletColor);
        bulletColor.SetColor("_EmissionColor", normBulletEmission);
    }

    private void OnApplicationQuit()
    {
        bulletColor.SetColor("_Color", normBulletColor);
        bulletColor.SetColor("_EmissionColor", normBulletEmission);
    }

}
