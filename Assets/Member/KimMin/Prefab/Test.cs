using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IPoolable
{
    public string PoolName => "Test";

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        gameObject.SetActive(false);
    }
}
