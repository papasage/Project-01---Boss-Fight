using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;

    [Header("Damage Visuals")]
    [SerializeField] GameObject deathPrefab;
    [SerializeField] GameObject deathPrefabLocation;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] GameObject damagePrefabLocation;
    [SerializeField] ColorLerper damageColors;

    [Header("Camera Shake Info")]
    public CameraShake cameraShake;
    [SerializeField] float damageCameraShakeDuration;
    [SerializeField] float damageCameraShakeMagnitude;
    [SerializeField] float killCameraShakeMagnitude;
    [SerializeField] float killCameraShakeDuration;

    [SerializeField] bool isPlayer;
    [SerializeField] bool isBoss;
    private bool isLastBoss = false;
    public event Action BrotherDied;
    [SerializeField] Health _otherHealth;
    [SerializeField] PlayerHealthBar _playerHealthBar;

    //Character Portrait Stuff
    [SerializeField] CharacterPortraitController _portrait;
    public void takeDamage(int amount)
    {
        //Set the portrait to damaged
        _portrait.StartCoroutine("Hurt");

        //Lerp Colors from red
        damageColors.DamageFlash();

        //play damage particle
        Instantiate(damagePrefab, damagePrefabLocation.transform.position, Quaternion.identity);

        //CAMERA SHAKE FOR PLAYER ONLY
        if (isPlayer == true) { cameraShake.flinch(); }

        //subtract health
        currentHealth -= amount;

        //Health update for Player only
        if (isPlayer == true && _playerHealthBar != null) { _playerHealthBar.SetHealth(currentHealth); }

        //check if dead
        if (currentHealth <= 0)
        {
            //Set the portrait to dead 
            _portrait.isDead = true;

            //die
            Kill();
        }
    }

    public void Kill()
    {
        //CAMERA SHAKE FOR PLAYER ONLY
        if (isPlayer == true) { cameraShake.deathRattle(); }

        //if this is the boss, invoke the BrotherDied event
        if (isBoss == true && isLastBoss == false) { BrotherDied.Invoke(); isLastBoss = true; }

        //empty the player's health bar
        if (isPlayer == true && _playerHealthBar != null) { _playerHealthBar.SetHealth(currentHealth); }

        //Store this location for a particle object
        Vector3 currentLocation = gameObject.transform.position;

        //Spawn explosion particle object on location
        Instantiate(deathPrefab, deathPrefabLocation.transform.position, Quaternion.identity);

        //gonzo
        if (isPlayer == true) { Destroy(gameObject); }
        if (isBoss == true) { Destroy(gameObject); }
    }

    void Start()
    {
        //Start at max health
        currentHealth = maxHealth;

        //set "damage colors" to this objects instance of the color lerper script
        damageColors = GetComponent<ColorLerper>();

        //Fill the player's health bar
        if (isPlayer == true && _playerHealthBar != null) { _playerHealthBar.SetMaxHealth(maxHealth); }

    }
    private void Update()
    {
        //Update the player's health bar
        //if (isPlayer == true && _playerHealthBar != null) { _playerHealthBar.SetHealth(currentHealth); }

        //The boss' health bar is consolidated in TwinBossHealth.cs. That is where the boss healthbar is controlled
    }

    private void OnEnable()
    {
        if (_otherHealth != null) { _otherHealth.BrotherDied += OnBrotherDied; }
    }

    void OnBrotherDied()
    {
        isLastBoss = true;
    }
}
