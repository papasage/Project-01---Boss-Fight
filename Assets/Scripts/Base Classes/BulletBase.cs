using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    Rigidbody rb = null;
    [SerializeField] protected float travelSpeed = .25f;
    [SerializeField] protected int damage = 25;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] AudioClip impactSFX;
    //[SerializeField] LayerMask Killable;

    private void Awake()
    {
        //Debug.Log("Bullet Spawn!");
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
        //Debug.Log("Bullet Collision!");

        //check if the collided object has a IDamageable component
        IDamageable damageable = col.GetComponent<IDamageable>();
        //if it does, apply this bullet's damage rating
        if (damageable != null) { damageable.takeDamage(damage);}

        //Store this location for a particle object
        Vector3 currentLocation = gameObject.transform.position;

        //Spawn impact particle object on location
        Instantiate(explosionPrefab,currentLocation,Quaternion.identity);

        //Bullet is Detroyed
        Destroy(gameObject);
    }
}
