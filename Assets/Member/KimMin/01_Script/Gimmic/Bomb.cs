using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IPoolable
{
    public string PoolName => "BombExplosion";

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        gameObject.SetActive(false);
    }
}
