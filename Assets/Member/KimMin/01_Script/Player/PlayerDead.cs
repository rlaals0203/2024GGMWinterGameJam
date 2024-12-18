using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IPlayerComponent
{
    private Bullet _bullet;

    public void Initialize(Player player)
    {
        _bullet = player as Bullet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ICollisionable collisionable) ||
            collision.transform.CompareTag("Wall"))
        {
            ExplosionPlayer();
        }
    }

    private void ExplosionPlayer()
    {
        _bullet.gameObject.SetActive(false);
        PoolManager.Instance.Pop("ExplosionParticle");
    }
}
