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
        }
        
    }
}