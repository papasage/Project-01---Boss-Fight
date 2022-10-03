using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleExplostion : MonoBehaviour
{
    [SerializeField] private float alarm = 5000;
    private float timer = 0;
    [SerializeField] string soundFileName;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play(soundFileName);
    }

    void LateUpdate()
    {
        timer++;
        //Debug.Log("Timer = " + timer);

        if (timer >= alarm)
        {
            Destroy(gameObject);
        }
            
        
    }
}
