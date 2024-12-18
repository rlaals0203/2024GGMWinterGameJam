using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Barrier")) return;

        Explosion();
    }

    private void Explosion()
    {
        EffectPlayer effect = PoolManager.Instance.Pop("BombExplosion") as EffectPlayer;
        effect.SetPositionAndPlay(transform.position);
        gameObject.SetActive(false);
    }
}
