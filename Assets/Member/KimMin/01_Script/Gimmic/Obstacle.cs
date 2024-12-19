using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : ObstacleParent, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    private float _distance => (_player.transform.position - transform.position).magnitude;

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
}
