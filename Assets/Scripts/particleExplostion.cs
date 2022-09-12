using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleExplostion : MonoBehaviour
{
    private float alarm = 60;
    private float timer = 0;
    void LateUpdate()
    {
        timer++;

        if (timer >= alarm)
        {
            Destroy(gameObject);
       }
            
        
    }
}
