using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IBlowable
{
    public Rigidbody2D RigidCompo => AssignRigidbody();

    public Rigidbody2D AssignRigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}