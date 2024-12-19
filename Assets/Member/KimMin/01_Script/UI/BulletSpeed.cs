using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private Bullet _bullet;

    private TextMeshProUGUI _speedTxt;

    private void Awake()
    {
        _bullet = GameObject.Find("Player").GetComponent<Bullet>();
        _speedTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        _speedTxt.text = $"{Mathf.Round(_bullet.RigidCompo.velocity.magnitude * 10) / 10} m/s";
    }
}
