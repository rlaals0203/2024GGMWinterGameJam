using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    protected Player _player;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
}
