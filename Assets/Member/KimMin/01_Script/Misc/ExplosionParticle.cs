using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour, IPoolable
{
    public string PoolName => "ExplosionParticle";

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        PoolManager.Instance.Pop(PoolName);
    }
}
