using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseShot : MonoBehaviour
{
    public event Action<Vector2, Transform> OnShotEvent;

    private Transform _directionTrm;
    private Vector2 _shotDir;

    private void Awake()
    {
        _directionTrm = transform.Find("Direction");
    }

    private void Update()
    {
        Release();

        if (Input.GetKeyDown(KeyCode.Space))
            ShotBullet();
    }

    private void ShotBullet()
    {
        WindController.Instance.UpWind();
        OnShotEvent?.Invoke(_shotDir, transform);
    }

    private void Release()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _shotDir = _directionTrm.position - transform.position;
    }
}
