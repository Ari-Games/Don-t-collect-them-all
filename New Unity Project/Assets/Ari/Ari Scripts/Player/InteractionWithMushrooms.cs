using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;


public class InteractionWithMushrooms : MonoBehaviour
{
    private string mushroomTag = "Mushroom";
    [SerializeField] private ChangeStateWorld world;
    [SerializeField] private MushroomAddiction mushroomAddiction;


    public delegate void EatMushroom();
    public event EatMushroom mushroomEat;


    public void OnEat()
    {
        mushroomEat.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(mushroomTag))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnEat();
                world.Change();
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("HealthMushroom") && Input.GetKeyDown(KeyCode.E))
        {
            Damageable playerHealth;
            if (TryGetComponent<Damageable>(out playerHealth))
            {
                playerHealth.Damage(-25);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("DeathMushroom") && Input.GetKeyDown(KeyCode.E))
        {
            Damageable playerHealth;
            if (TryGetComponent<Damageable>(out playerHealth))
            {
                playerHealth.Damage(10);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("EnergyMushroom") && Input.GetKeyDown(KeyCode.E))
        {
            mushroomAddiction?.AddAddiction(0.1f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EnergyTakeMushroom") && Input.GetKeyDown(KeyCode.E))
        {
            mushroomAddiction?.AddAddiction(-0.1f);
            Destroy(collision.gameObject);
        }
    }

    
}
