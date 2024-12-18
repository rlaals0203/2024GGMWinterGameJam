using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Player, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    private void OnEnable()
    {
        releaseShot.OnShotEvent += HandleOnShot;
        WindController.Instance.OnWindChanged += HandleGravityChanged;
    }

    private void HandleGravityChanged()
    {
        WindController.Instance.SetVelocity(RigidCompo);
    }

    private void HandleOnShot(Vector2 shotDir, Transform gun)
    {
        WindController.Instance.UpWind();

        IsAwake = true;
        transform.position = new Vector2(
            gun.position.x + gun.transform.localScale.x / 2,
            gun.position.y);

        RigidCompo.simulated = true;
        RigidCompo.AddForce(shotDir * ShotPower);
    }

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}
