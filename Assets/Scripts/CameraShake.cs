using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float _mag;
    private float _dur;
    private Vector3 originalPos;

    public IEnumerator Shake (float duration, float magnitude)
    {
        //STORE THE LOCAL VARIABLES 
        _dur = duration;
        _mag = magnitude;
        originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < _dur)
        {

            if (_mag >= 0) { _mag -= 0.001f; }

            float x = Random.Range(-1f, 1f) * _mag;
            float y = Random.Range(-1f, 1f) * _mag;

            transform.localPosition = new Vector3(x, y,originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void rumble()
    {
        //smallest camera shake event for boss enraged
        StartCoroutine(Shake(.15f, .18f));
    }
    public void recoil()
    {
        // small camera shake event for player gunfire
        StartCoroutine(Shake(.15f, .20f));
    }
    public void flinch()
    {
        // medium camera shake event for player damage
        StartCoroutine(Shake(.3f, .4f));
    }
    public void deathRattle()
    {
        // big camera shake event for death
        StartCoroutine(Shake(2f, 3f));
    }
}
