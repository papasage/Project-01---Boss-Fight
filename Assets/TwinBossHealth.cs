using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwinBossHealth : MonoBehaviour
{
    [SerializeField] Text hpCounter;
    [SerializeField] private Health _healthA;
    [SerializeField] private Health _healthB;
    float twinHealthCurrent;
    float twinHealthMax;
    

    void Update()
    {
        CombineHealths();
        UpdateHealthUI();
    }

    void CombineHealths()
    {
        twinHealthCurrent = _healthA.currentHealth + _healthB.currentHealth;
        twinHealthMax = _healthA.maxHealth + _healthB.maxHealth;
    }

    void UpdateHealthUI()
    {
        if (twinHealthCurrent <= 0)
        {
            hpCounter.text = "EXTERMINATED";
        }

        else hpCounter.text = "HP:" + twinHealthCurrent;
    }
}
