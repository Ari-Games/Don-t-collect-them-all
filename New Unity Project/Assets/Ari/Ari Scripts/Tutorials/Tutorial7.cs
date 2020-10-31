using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial7 : MonoBehaviour
{
    [SerializeField] private Text task;
    [SerializeField] private string textTask;
    [SerializeField] private string textTask2;
    [SerializeField] private string textTask3;
    [SerializeField] private IsCollision trig1;
    [SerializeField] private IsCollision trig2;
    [SerializeField] private GameObject enemy;
    private bool isSpawn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            task.text = textTask;
        }
    }

    private void Update()
    {
        if (trig1.IsTrigger)
        {
            task.text = textTask2;
            trig1.enabled = false;
        }
        if (trig2.IsTrigger)
        {
            task.text = textTask3;
        }
        if (trig2.IsTrigger && !isSpawn)
        {
            isSpawn = true;
            enemy.SetActive(true);
        }
        if (trig2.IsTrigger && isSpawn && enemy.transform.childCount == 0)
        {
            Destroy(this.gameObject);
            task.text = "";
        }
    }

}
