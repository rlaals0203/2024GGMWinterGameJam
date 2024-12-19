using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WindParticle : MonoBehaviour, IPlayerComponent
{
    private Bullet _bullet;
    private ParticleSystem _particleSystem;

    private float _distance = 25f;

    public void Initialize(Player player)
    {
        _bullet = player as Bullet;

        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        SetRotation();
        SetParticle();
    }

    private void SetParticle()
    {
        var emission = _particleSystem.emission;
        emission.rateOverTime = _bullet.RigidCompo.velocity.magnitude / 1.5f;
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, (_bullet.VisualCompo.transform.rotation.z * 120));
    }
}
