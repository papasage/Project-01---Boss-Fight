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

    Color testColor;

    private void Start()
    {
        foreach (LerpMaterial lm in materials)
        {
            //switch to the damage color instantly
                                                                 //lm.material.SetColor("_Color", lm.startColor);
            lm.material.color = lm.startColor;
        }
    }

    private void Update()
    {

        if (lerpTime == true)
        {
            lerpArray();
        }

    }
    public void setLerp()
    //THIS IS THE FUNCTION WE CALL TO TRIGGER THE FLASH
    //It sets the array'd materials to the target color, then tr
    {
        float t = 0;
        foreach (LerpMaterial lm in materials)
        {
            //switch to the damage color instantly
                                                                     //lm.material.SetColor("_Color",targetColor);
            lm.material.color = targetColor;
        }

        //Debug.Log("lerp button pressed");
        lerpTime = true;
    }
    void lerpArray()
    {
        float lastLerpStart = Time.time;
        foreach (LerpMaterial lm in materials)
        {
            //lerp back to starting colors
            float t = Mathf.Sin((Time.time * lerpSpeed));
            //Debug.Log("Material Lerp Progress = " + t);
            testColor = Color.Lerp(targetColor, lm.startColor, t);
                                                                     //lm.material.SetColor("_Color", testColor);
            lm.material.color = Color.Lerp(targetColor, lm.startColor, t);


            if (t >= tTarget)
            {
                                                                     //lm.material.SetColor("_Color", lm.startColor);
                lm.material.color = lm.startColor;
                lerpTime = false;
                break;
            }

            //QUESTION FOR CHANDLER:
            //I think the way I am using t as a timer to determine where we are in the lerp is causing issues when I break the loop
            //sometimes (very rarely) I notice that not all of the materials will lerp back to normal. 

            //because all of the materials have their own seperate "timer" (t / tTarget), they dont always hit the target value at the same time. 
            //this causes a chance that some materials will not catch the flag to return to normal

            //i am exhausted 
        }
    }

}
