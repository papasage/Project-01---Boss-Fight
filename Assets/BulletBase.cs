using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] protected float travelSpeed = .25f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 moveOffset = transform.forward * travelSpeed;
        rb.MovePosition(rb.position + moveOffset);
    }
}
