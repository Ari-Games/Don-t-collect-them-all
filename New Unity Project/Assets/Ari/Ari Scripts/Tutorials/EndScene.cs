﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private GameObject book;
    [SerializeField] private Text bookText;
    [SerializeField] private string endText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            book.SetActive(true);
            bookText.text = endText;
            StartCoroutine(End());
        }
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
