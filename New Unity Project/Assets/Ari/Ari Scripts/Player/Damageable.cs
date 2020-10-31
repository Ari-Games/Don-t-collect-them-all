using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    [SerializeField] int healthPoint = 100;
    int standartHPValue;


    public int HealthPoint
    {
        get { return healthPoint; }
        set 
        {            
            healthPoint = value;
            if (healthPoint <= 0)
            {
                Death();
            }   
        }
    }

    public int StandartHP
    {
        get { return standartHPValue; }
    }
    private void Start() {
        standartHPValue = healthPoint;
    }

    public void Damage(int damage)
    {
        HealthPoint -= damage;
    }
    public void Death()
    {
        print("You are dead!");
    }
}
