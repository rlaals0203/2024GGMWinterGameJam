using System;
using UnityEngine;

public class WindController : MonoSingleton<WindController>
{
    public const float GRAVITY = 9.81f;
    public event Action OnWindChanged;

    public bool isHorizontal = true;

	private float gravityScale = 2f;
	private float changeTime = 0.05f;

    public Vector2 currentGravity = Vector2.zero;
    private Vector2 prevGravity = Vector2.zero;

    private void Awake()
    {
        Physics2D.gravity = new Vector2(0, 0);
    }

    private void Update()
    {
        ChangeWind();
    }

    public void SetVelocity(Rigidbody2D rigid)
    {
        Vector2.Lerp(rigid.velocity, rigid.velocity / 2, changeTime);
    }

    private void ChangeWind()
    {
        if (isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.W)) UpWind();
            else if (Input.GetKeyDown(KeyCode.S)) DownWind();
        }
        else if(!isHorizontal)
        {
            if (Input.GetKeyDown(KeyCode.A)) LeftWind();
            else if (Input.GetKeyDown(KeyCode.D)) RightWind();
        }

        if (currentGravity != Vector2.zero && prevGravity != currentGravity)
            SetWind(currentGravity);
    }

    private void SetWind(Vector2 direction)
	{
        Physics2D.gravity = direction * gravityScale;
        prevGravity = direction;

        OnWindChanged?.Invoke();
    }

    public void UpWind()
    {
        currentGravity = new Vector2(0, GRAVITY);
    }

    public void DownWind()
    {
        currentGravity = new Vector2(0, -GRAVITY);
    }

    public void LeftWind()
    {
        currentGravity = new Vector2(-GRAVITY, 0);
    }

    public void RightWind()
    {
        currentGravity = new Vector2(GRAVITY, 0);
    }
}
