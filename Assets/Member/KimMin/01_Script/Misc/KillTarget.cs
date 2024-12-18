using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public event Action OnKillEvent;

    private Bullet _bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            _bullet = bullet;
            OnKillEvent += bullet.HandleKillTarget;

            OnKillEvent?.Invoke();
        }
    }

    private void OnDisable()
    {
        if (_bullet != null)
            OnKillEvent -= _bullet.HandleKillTarget;
    }
}
