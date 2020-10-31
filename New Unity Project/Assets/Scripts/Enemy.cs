using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int Health { get; private set; }
    void Start()
    {
        Health = 100;
    }

    public void PushEnemy(int damage)
    {
        Health -= damage;
        if (Health<=0)
        {
            Death();
        }
    }
    public abstract  void Death();
    
    void Update()
    {
        
    }
}
