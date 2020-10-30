using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    [SerializeField] int healthPoint = 5;
    int standartHPValue;


    public int HealthPoint
    {
        get { return healthPoint; }
        set { healthPoint = value; }
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
        healthPoint -= damage;
    }
}
