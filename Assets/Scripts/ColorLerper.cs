using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorLerper : MonoBehaviour
{
    public LerpMaterial[] materials;
    [SerializeField] Color targetColor = Color.white;
    [SerializeField] float lerpSpeed = 1.0f;
    float startTime;

    private void Start()
    {
        float startTime = Time.time;
    }

    private void Update()
    {
        foreach (LerpMaterial lm in materials)
        {
            //LerpMaterial lerpmat = Array.Find(materials, lerpmaterial => lerpmaterial.material);
            float t = (Mathf.Sin(Time.time - startTime) * lerpSpeed);
            lm.material.color = Color.Lerp(lm.startColor, targetColor, t); 
        }
    }

}
