using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;

    public event Action OnDamageTaken; 

    public void TakeDamage(int damage)
    {
        Health -= damage;
        OnDamageTaken?.Invoke();
    }
}
