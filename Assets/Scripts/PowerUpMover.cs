using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMover : MonoBehaviour
{
    //hookup to see the BrotherDied event
    [SerializeField] private Health _healthA;
    [SerializeField] private Health _healthB;
    bool _ready = false;
    public void OnBrotherDied()
    {
        _ready = true;
    }


    private void OnEnable()
    {
        if (_healthA != null) { _healthA.BrotherDied += OnBrotherDied; }
        if (_healthB != null) { _healthB.BrotherDied += OnBrotherDied; }
    }
    private void OnDisable()
    {
        if (_healthA != null) { _healthA.BrotherDied -= OnBrotherDied; }
        if (_healthB != null) { _healthB.BrotherDied -= OnBrotherDied; }
    }

    void Update()
    {
        if (gameObject.transform.position.y >= 0.79f && _ready == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5);
        }

    }
}
