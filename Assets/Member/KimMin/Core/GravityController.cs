using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class GravityController : MonoSingleton<GravityController>
{
    public event Action OnGravityChaged;

	public float gravityScale = 1f;
	public float changeTime = 0.1f;

    public Vector2 currentGravity = Vector2.zero;
    private Vector2 prevGravity = Vector2.zero;

    private void Update()
    {
        ChangeGravity();

        Debug.Log(Physics2D.gravity);
    }

    public void SetVelocity(Rigidbody2D rigid)
    {
        /*        DOTween.To(() => rigid.velocity, x => rigid.velocity = x, rigid.velocity / 2f, 0.25f)
                    .SetEase(Ease.OutCubic);*/

        Vector2.Lerp(rigid.velocity, rigid.velocity / 2, changeTime);
    }

    private void ChangeGravity()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        x = x == 0 ? 0 : Mathf.Sign(x);
        y = y == 0 ? 0 : Mathf.Sign(y);

        currentGravity = new Vector2(x, y);

        if (currentGravity != Vector2.zero && prevGravity != currentGravity)
            SetGravity(currentGravity);
    }

    private void SetGravity(Vector2 direction)
	{
        OnGravityChaged?.Invoke();
        Physics2D.gravity = direction * 9.81f * gravityScale;
        prevGravity = direction;

        SetVelocity(GetComponent<Rigidbody2D>());
    }
}
