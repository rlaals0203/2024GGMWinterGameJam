using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour, IPlayerComponent
{
    private Bullet _bullet;
    private SpriteRenderer _renderer;

    public void Initialize(Player player)
    {
        _bullet = player as Bullet;
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.enabled = false;
    }

    private void Start()
    {
        _bullet.releaseShot.OnShotEvent += HandleOnShot;
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void HandleOnShot(Vector2 vector, Transform gun)
    {
        _renderer.enabled = true;
    }

    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(_bullet.RigidCompo.velocity.y,
            _bullet.RigidCompo.velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
