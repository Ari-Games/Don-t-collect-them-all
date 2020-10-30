using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image image;
    private Damageable damageable;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        damageable = GameObject.FindWithTag("Player").GetComponent<Damageable>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var curHP = ((float)damageable.HealthPoint / (float)damageable.StandartHP);
        image.fillAmount = curHP;
    }
}
