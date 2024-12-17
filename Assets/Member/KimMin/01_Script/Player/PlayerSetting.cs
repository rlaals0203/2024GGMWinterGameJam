using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public Rigidbody2D RigidCompo { get; protected set; }
    public bool IsAwake { get; protected set; } = false;

    public ReleaseShot releaseShot;

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
    }
}
