using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : Player, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    private void OnEnable()
    {
        releaseShot.OnShotEvent += HandleOnShot;
        WindController.Instance.OnWindChanged += HandleGravityChanged;
    }

    private void FixedUpdate()
    {
        BulletMove();
    }

    private void HandleGravityChanged()
    {
        WindController.Instance.SetVelocity(RigidCompo);
    }

    private void HandleOnShot(Vector2 shotDir, Transform gun)
    {
        WindController.Instance.UpWind();
        CameraPos.transform.DOShakePosition(0.1f, 4f);

        transform.position = new Vector2(
            gun.position.x + gun.transform.localScale.x / 2,
            gun.position.y);

        RigidCompo.simulated = true;
        RigidCompo.AddForce(shotDir * shotPower);

        float diffrence = Quaternion.Angle(gun.rotation, Quaternion.Euler(0, 0, 0));

        if (diffrence < 45)
        {
            moveDir = Vector2.right;
        }
        else if (diffrence > 45 && diffrence < 90)
        {
            moveDir = Vector2.right;
        }

    }

    private void BulletMove()
    {
        RigidCompo.AddForce(moveDir * bulletSpeed);
    }

    public void HandleKillTarget()
    {

    }

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}
