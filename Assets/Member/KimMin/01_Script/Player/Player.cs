using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerSetting
{
    private void OnEnable()
    {
        releaseShot.OnShotEvent += HandleOnShot;
        WindController.Instance.OnGravityChange += HandleGravityChanged;
    }

    private void HandleGravityChanged()
    {
        WindController.Instance.SetVelocity(RigidCompo);
    }

    private void HandleOnShot(Vector2 shotDir)
    {
        WindController.Instance.UpWind();

        IsAwake = true;
        RigidCompo.simulated = true;
        RigidCompo.AddForce(Vector2.up * 100);
    }
}
