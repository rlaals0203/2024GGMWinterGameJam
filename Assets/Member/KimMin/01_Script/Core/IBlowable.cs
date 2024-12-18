using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlowable
{
    public Rigidbody2D RigidCompo { get; }

    public void AssignRigidbody();
}
