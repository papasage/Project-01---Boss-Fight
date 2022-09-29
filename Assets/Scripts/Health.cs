using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    [Header("Damage Visuals")]
    [SerializeField] GameObject deathPrefab;
    [SerializeField] GameObject deathPrefabLocation;
    [SerializeField] ColorLerper damageColors;

    [Header("Camera Shake Info")]
    public CameraShake cameraShake;
    [SerializeField] float damageCameraShakeDuration;
    [SerializeField] float damageCameraShakeMagnitude;
    [SerializeField] float killCameraShakeMagnitude;
    [SerializeField] float killCameraShakeDuration;

    [SerializeField] bool isPlayer;
    public void takeDamage(int amount)
    {
        //Lerp Colors from red
        damageColors.setLerp();

        //CAMERA SHAKE FOR PLAYER ONLY
        if (isPlayer == true) { cameraShake.flinch(); }
        
        //subtract health
        currentHealth -= amount;
        
        //check if dead
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        //CAMERA SHAKE FOR PLAYER ONLY
        if (isPlayer == true) { cameraShake.deathRattle(); }
        

        //Store this location for a particle object
        Vector3 currentLocation = gameObject.transform.position;

        //Spawn explosion particle object on location
        Instantiate(deathPrefab, deathPrefabLocation.transform.position, Quaternion.identity);

        //gonzo
        Destroy(gameObject);
    }

    void Start()
    {
        //Start at max health
        currentHealth = maxHealth;

        //set "damage colors" to this objects instance of the color lerper script
        damageColors = GetComponent<ColorLerper>();
    }

  
}
