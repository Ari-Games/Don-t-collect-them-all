using Assets.Scripts;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image image;
    private Damageable damageable;
    [SerializeField] private GameObject deathPanel;
    private bool flag = false;
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
        if (damageable.HealthPoint <= 0.01 && !flag)
        {
            flag = true;
            deathPanel.SetActive(true);
            damageable.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0;
        }
    }
}
