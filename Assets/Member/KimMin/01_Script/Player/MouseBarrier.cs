using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseBarrier : MonoBehaviour
{
    [SerializeField] private float _hitPower;
    private Vector2 _mosuePos;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate ()
    {
        SetBarrierPosition();
    }

    private void SetBarrierPosition()
    {
        _mosuePos = GetMousePos();
        transform.position = _mosuePos;
    }

    private Vector2 GetMousePos() => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IBlowable blowable))
        {
            blowable.RigidCompo.AddForce((collision.transform.position - 
                transform.position).normalized * _hitPower);

            Debug.Log(blowable.RigidCompo.transform.name);
        }
    }
}
