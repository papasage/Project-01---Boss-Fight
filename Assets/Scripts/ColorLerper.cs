using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorLerper : MonoBehaviour
{
    public LerpMaterial[] materials;
    [SerializeField] Color targetColor = Color.white;
    [SerializeField] float secondsForLerp = 1f;

    private void Update()
    {
            foreach (LerpMaterial lm in materials)
            {
                lm.material.color = Color.Lerp(lm.material.color, lm.startColor, Time.deltaTime * secondsForLerp);
            }
    }

    public IEnumerator DamageFlash()
    {
        foreach (LerpMaterial lm in materials)
        {
            lm.material.color = targetColor;
        }
          
        return null;
    }

    //Cleanup crew
    private void Start()
    {
        foreach (LerpMaterial lm in materials)
        {
            lm.material.color = lm.startColor;
        }
    }

    private void OnDisable()
    {
        foreach (LerpMaterial lm in materials) { lm.material.color = lm.startColor; }
    }

    private void OnDestroy()
    {
        foreach (LerpMaterial lm in materials) { lm.material.color = lm.startColor; }
    }

    private void OnApplicationQuit()
    {
        foreach (LerpMaterial lm in materials) { lm.material.color = lm.startColor; }
    }

}
