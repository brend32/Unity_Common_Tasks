using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Fill;
    public Enemy Target;

    private void OnEnable()
    {
        Target.OnDamageTaken += OnEnemyDamageTaken;
    }

    private void OnDisable()
    {
        Target.OnDamageTaken -= OnEnemyDamageTaken;
    }

    private void OnEnemyDamageTaken()
    {
       SetValue(Target.Health, 100); 
    }

    public void SetValue(int health, int maxHealth)
    {
        float percent = health / (float)maxHealth;
        Fill.fillAmount = percent;
    }
    
    // 100 - 1
    // x - 0.5
    
    // 100 * 0.5 / 1
    // value / max
    // 1000 / 5000
}
