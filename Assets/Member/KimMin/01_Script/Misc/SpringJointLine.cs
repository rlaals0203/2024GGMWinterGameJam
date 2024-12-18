using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SpringJointLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Transform _target;

    private void Awake()
    {
        _target = transform.Find("Target");

        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        SetLine();
    }

    private void SetLine()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _target.transform.position);
    }
}
