using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorLerper : MonoBehaviour
{
    public LerpMaterial[] materials;
    [SerializeField] Color targetColor = Color.white;
    [SerializeField] float lerpSpeed = 1.0f;
    [SerializeField] bool lerpTime = false;
    [SerializeField] float tTarget;

    private void Start()
    {
        foreach (LerpMaterial lm in materials)
        {
            //switch to the damage color instantly
            lm.material.color = lm.startColor;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            setLerp();
        }

        if (lerpTime == true)
        {
            lerpArray();
        }



    }
    public void setLerp()
    {
        float t = 0;
        foreach (LerpMaterial lm in materials)
        {
            //switch to the damage color instantly
            lm.material.color = targetColor;
        }

        Debug.Log("lerp button pressed");
        lerpTime = true;
    }
    void lerpArray()
    {
        float lastLerpStart = Time.time;
        foreach (LerpMaterial lm in materials)
        {
            
            //lerp back to starting colors
            float t = Mathf.Sin((Time.time * lerpSpeed));
            Debug.Log("T= " + t);
            lm.material.color = Color.Lerp(targetColor, lm.startColor, t);

            if (t >= tTarget)
            {
                lm.material.color = lm.startColor;
                lerpTime = false;
                break;
            }
        }
    }

}
