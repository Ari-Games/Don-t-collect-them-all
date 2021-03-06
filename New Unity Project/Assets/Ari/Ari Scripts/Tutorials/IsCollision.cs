﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollision : MonoBehaviour
{
    public bool IsTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            IsTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            IsTrigger = true;
        Debug.Log("Good");
    }
}
