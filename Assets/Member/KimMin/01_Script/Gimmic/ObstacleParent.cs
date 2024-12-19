using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    protected Bullet _bullet;

    private void Awake()
    {
        _bullet = GameObject.Find("Player").GetComponent<Bullet>();
    }
}
