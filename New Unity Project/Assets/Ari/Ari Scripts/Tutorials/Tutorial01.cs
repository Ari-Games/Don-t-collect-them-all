using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial01 : MonoBehaviour
{
    [SerializeField] private Text task;
    [SerializeField] private string textTask;
    [SerializeField] private bool isTimeOfEnd;
    [SerializeField] private int secondToEnd;
    [SerializeField] private GameObject[] UIHid;

    private IEnumerator WaitAndEnd()
    {
        yield return new WaitForSeconds(secondToEnd);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            task.text = textTask;
            if (isTimeOfEnd)
                StartCoroutine(WaitAndEnd());
        }
    }
    private void Update()
    {
        if (GWorld.IsOurWorld())
            foreach (var ui in UIHid)
                ui.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GWorld.IsOurWorld())
            Destroy(this.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            task.text = "";
    }
}
