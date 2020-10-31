using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial3 : MonoBehaviour
{
    [SerializeField] private Text task;
    [SerializeField] private string textTask;
    [SerializeField] private IsCollision trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            task.text = textTask;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && trigger.IsTrigger)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            task.text = "";
    }
}
