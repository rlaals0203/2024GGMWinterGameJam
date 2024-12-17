using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private SpriteRenderer _renderer;

    public void Initialize(Player player)
    {
        _player = player;
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.enabled = false;
    }

    private void Start()
    {
        _player.releaseShot.OnShotEvent += HandleOnShot;
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
        float angle = Mathf.Atan2(_player.RigidCompo.velocity.y, 
            _player.RigidCompo.velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
