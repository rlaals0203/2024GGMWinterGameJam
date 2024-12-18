using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseBarrier : MonoBehaviour
{
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

        }
    }
}
