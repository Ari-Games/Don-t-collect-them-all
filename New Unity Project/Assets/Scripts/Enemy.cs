using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health 
    {
        get { return health; }
        private set 
        {
            health = value;
        }
    }
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
