using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && 
            collision.transform.TryGetComponent(out IBlowable blowable))
        {
            blowable.RigidCompo.velocity *= 2;
        }
    }
}
