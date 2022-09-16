using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject deathPrefab;
    [SerializeField] GameObject deathPrefabLocation;

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        //Store this location for a particle object
        Vector3 currentLocation = gameObject.transform.position;

        //Spawn impact particle object on location
        Instantiate(deathPrefab, deathPrefabLocation.transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

  
}
