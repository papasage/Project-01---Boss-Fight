using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    //hookup to see the BrotherDied event
    [SerializeField] private Health _healthA;
    [SerializeField] private Health _healthB;

    [SerializeField] Transform _spawnLocation;
    [SerializeField] Object _powerup;

    public void OnBrotherDied()
    {
        Instantiate(_powerup, _spawnLocation);
    }


    private void OnEnable()
    {
        if (_healthA != null) { _healthA.BrotherDied += OnBrotherDied; }
        if (_healthA != null) { _healthA.BrotherDied += OnBrotherDied; }
    }
    private void OnDisable()
    {
        if (_healthA != null) { _healthA.BrotherDied -= OnBrotherDied; }
        if (_healthA != null) { _healthA.BrotherDied -= OnBrotherDied; }
    }
}
