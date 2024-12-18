using System;
using UnityEngine;

public class JH_Bo : MonoBehaviour
{
    public Action Onhit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Onhit?.Invoke();
        }
    }
}