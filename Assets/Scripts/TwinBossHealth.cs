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
    public BossHealthBar _bossHealthBar;

    private void Start()
    {
        twinHealthMax = _healthA.maxHealth + _healthB.maxHealth;
        _bossHealthBar.SetMaxHealth(twinHealthMax);
    }

    void Update()
    {
        CombineHealths();
        UpdateHealthUI();
    }

    void CombineHealths()
    {
        twinHealthCurrent = _healthA.currentHealth + _healthB.currentHealth;
    }

    void UpdateHealthUI()
    {
        _bossHealthBar.SetHealth(twinHealthCurrent);
    }
}
