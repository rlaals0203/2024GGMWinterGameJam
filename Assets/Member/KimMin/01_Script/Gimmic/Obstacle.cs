using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : ObstacleParent, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    private float _distance => (_bullet.transform.position - transform.position).magnitude;

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_distance < 10f)
        {
            RigidCompo.simulated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Barrier"))
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        _bullet.CameraPos.transform.DOShakePosition(0.02f, 4, 10, 5f).SetEase(Ease.InOutElastic);

        AudioManager.Instance.PlaySound("BreakObstacle");
        EffectPlayer effect =  PoolManager.Instance.Pop("BrokeParticle") as EffectPlayer;
        effect.SetPositionAndPlay(transform.position);
        gameObject.SetActive(false);
    }
}
