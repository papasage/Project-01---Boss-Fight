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

    //variables that control the fire intervals
    float shotTimer = 1;
    bool fireAgain = false;
    [SerializeField] float coolDownSeconds = 1;
    [SerializeField] float coolDownSecondsPower = .3f;

    //camera shake connection
    public CameraShake cameraShake;
    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeMagnitude;

    //music change connection for powerup
    [SerializeField] MusicChanger _music;


    private void Start()
    {
        bulletColor.SetColor("_Color", normBulletColor);
        bulletColor.SetColor("_EmissionColor", normBulletEmission);
    }
    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
        if (Input.GetKey(KeyCode.P))
        {
            PowerUp(coolDownSecondsPower);
        }
    }

    private void Update()
    {
        AutoFire(coolDownSeconds);
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
        cameraShake.recoil();
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

    void PowerUp(float cooldownBuff)
    {
        coolDownSeconds = cooldownBuff;
        bulletColor.SetColor("_Color", powerBulletColor);
        bulletColor.SetColor("_EmissionColor", powerBulletEmission);
        _music.Phase3();
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
