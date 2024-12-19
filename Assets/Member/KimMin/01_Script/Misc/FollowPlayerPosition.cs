using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    private Transform _playerTrm;

    private void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = _playerTrm.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = collision.contacts[0].point;
    }
}
