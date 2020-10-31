using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial8 : MonoBehaviour
{
    [SerializeField] private Text task;
    [SerializeField] private string textTask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            task.text = textTask;
        }
    }

    private void Update()
    {

    }
}
