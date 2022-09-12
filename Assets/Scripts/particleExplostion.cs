using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleExplostion : MonoBehaviour
{
    private float alarm = 60;
    private float timer = 0;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("projectile_impact");
    }

    void LateUpdate()
    {
        timer++;

        if (timer >= alarm)
        {
            Destroy(gameObject);
       }
            
        
    }
}
