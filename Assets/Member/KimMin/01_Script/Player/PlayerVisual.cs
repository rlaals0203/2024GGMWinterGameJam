using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(_player.RigidCompo.velocity.y, 
            _player.RigidCompo.velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
