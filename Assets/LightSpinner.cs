using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpinner : MonoBehaviour
{
    //hookup to see the BrotherDied event
    [SerializeField] private Health _health;
    Light _thisLight;
    [SerializeField] float spinSpeed;
    bool isEnraged = false;

    private void OnEnable()
    {
        if (_health != null) { _health.BrotherDied += OnBrotherDied; }

    }

    public void OnBrotherDied()
    {
        isEnraged = true;
    }

    void Update()
    {
     if (isEnraged == true)
        {
            Quaternion target = Quaternion.Euler(0, transform.rotation.y + spinSpeed, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime);
        }   
    }
}
