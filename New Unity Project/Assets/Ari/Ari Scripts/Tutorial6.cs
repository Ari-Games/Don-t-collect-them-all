using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial6 : MonoBehaviour
{
    [SerializeField] private Text task;
    [SerializeField] private string textTask;
    [SerializeField] private string textTask2;
    [SerializeField] private IsCollision trigger;
    [SerializeField] private int seconds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            task.text = textTask;
        }
    }

    private void Update()
    {
        if (trigger.IsTrigger)
        {
            StartCoroutine(EndTask());
        }
    }

    private IEnumerator EndTask()
    {
        task.text = textTask2;
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
        task.text = "";
    }
}
