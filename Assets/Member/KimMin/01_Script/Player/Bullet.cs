using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Linq.Expressions;
using UnityEngine.SceneManagement;

public class Bullet : Player, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    private void OnEnable()
    {
        releaseShot.OnShotEvent += HandleOnShot;
        OnSceneLoadComplete += HandleSceneLoaded;
        WindController.Instance.OnWindChanged += HandleGravityChanged;
    }

    private void OnDisable()
    {
        releaseShot.OnShotEvent -= HandleOnShot;
        OnSceneLoadComplete -= HandleSceneLoaded;
        //WindController.Instance.OnWindChanged -= HandleGravityChanged;
    }

    private void Start()
    {
        startPos = GameObject.Find("Gun").transform;
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
        if (!CanShot) return;

        WindController.Instance.UpWind();
        CameraPos.transform.DOShakePosition(0.1f, 4f);

        transform.position = new Vector2(
            gun.position.x + gun.transform.localScale.x / 2,
            gun.position.y);

        RigidCompo.simulated = true;
        RigidCompo.AddForce(shotDir * shotPower);
        CameraPos.parent = transform;

        float diffrence = Quaternion.Angle(gun.rotation, Quaternion.Euler(0, 0, 0));

        if (diffrence < 45)
            moveDir = Vector2.right;
        else if (diffrence > 45 && diffrence < 90)
            moveDir = Vector2.right;

        CanShot = false;
        AudioManager.Instance.PlaySound("Shot");
    }

    private void BulletMove()
    {
        RigidCompo.AddForce(moveDir * bulletSpeed);
    }

    public void HandleKillTarget()
    {
        ResetBullet();
    }

    private void HandleSceneLoaded()
    {
        ResetBullet();
    }

    public void ResetBullet()
    {
        transform.localRotation = Quaternion.identity;
        RigidCompo.velocity = Vector2.zero;
        transform.position = startPos.position;

        CameraPos.parent = gunTrm.transform;

        VisualCompo.renderer.enabled = false;
        CanShot = true;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}
