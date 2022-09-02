using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Rigidbody rbMain = null;
    [SerializeField] Rigidbody rbTurret = null;

    [SerializeField] float maxSpeed = .25f;
    [SerializeField] float turnSpeed = 2f;

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
        TurnTurret();
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

    }
}
