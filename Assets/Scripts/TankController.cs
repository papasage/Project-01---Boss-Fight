using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Rigidbody rbMain = null;
    [SerializeField] Rigidbody rbTurret = null;

    [SerializeField] float maxSpeed = .25f;
    [SerializeField] float turnSpeed = 2f;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firepoint;

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
        TurnTurret();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("FIRE!");
            Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
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

    public void TurnTurret()
    {
        Vector3 mousePos = Input.mousePosition;
        //rbTurret.transform.LookAt(mousePos);
    }
}
