using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticle : MonoBehaviour, IPlayerComponent
{
    private Bullet _bullet;
    private ParticleSystem _particleSystem;

    public void Initialize(Player player)
    {
        _bullet = player as Bullet;

        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void SetParticle()
    {

    }

}
