using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    Rigidbody rb = null;
    [SerializeField] protected float travelSpeed = .25f;
    //[SerializeField] LayerMask Killable;

    private void Awake()
    {
        Debug.Log("Bullet Spawn!");
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

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Bullet Collision!");
        //TODO APPLY DAMAGE HERE
      
        if(col.gameObject.layer == LayerMask.NameToLayer("Killable"))
        {
            Destroy(col.gameObject); 
        }
        
        gameObject.SetActive(false);
    }
}
