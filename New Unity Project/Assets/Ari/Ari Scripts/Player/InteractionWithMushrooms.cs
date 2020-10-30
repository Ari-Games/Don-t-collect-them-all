using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

namespace Assets.Ari.Ari_Scripts.Player
{
    public class InteractionWithMushrooms : MonoBehaviour
    {
        private string mushroomTag = "Mushroom";
        [SerializeField] private ChangeStateWorld world;
        [SerializeField] private MushroomAddiction mushroomAddiction;
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(mushroomTag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    world.Change();
                    Destroy(collision.gameObject);
                }
            }
            if (collision.gameObject.CompareTag("HealthMushroom") && Input.GetKeyDown(KeyCode.E))
            {
                Damageable playerHealth;
                if (TryGetComponent<Damageable>(out playerHealth))
                {
                    playerHealth.Damage(-10);
                }
            }
            if (collision.gameObject.CompareTag("DeathMushroom") && Input.GetKeyDown(KeyCode.E))
            {
                Damageable playerHealth;
                if (TryGetComponent<Damageable>(out playerHealth))
                {
                    playerHealth.Damage(10);
                }
            }
            if (collision.gameObject.CompareTag("EnergyMushroom") && Input.GetKeyDown(KeyCode.E))
            {
                mushroomAddiction?.AddAddiction(0.1f);
            }
            if (collision.gameObject.CompareTag("EnergyTakeMushroom") && Input.GetKeyDown(KeyCode.E))
            {
                mushroomAddiction?.AddAddiction(-0.1f);
            }
        }

        
    }
}