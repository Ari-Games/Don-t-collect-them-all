using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial5 : MonoBehaviour
{
    [SerializeField] private Transform pointRespawn;
    [SerializeField] private IsCollision trigger;
    [SerializeField] private GameObject[] ui;
    [SerializeField] private GameObject wall;
    private void Update()
    {
        if (trigger.IsTrigger && GWorld.IsOurWorld())
        {
            foreach (var elem in ui)
                elem.SetActive(true);
            trigger.enabled = false;
            wall.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = pointRespawn.position;
        }
    }
}
