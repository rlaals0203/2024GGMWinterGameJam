using UnityEngine;

public class GravityController : MonoSingleton<GravityController>
{
    public const float GRAVITY = 9.81f;

	public float gravityScale = 1f;
	public float changeTime = 0.1f;

    public Vector2 currentGravity = Vector2.zero;
    private Vector2 prevGravity = Vector2.zero;

    private void Update()
    {
        ChangeGravity();
    }

    public void SetVelocity(Rigidbody2D rigid)
    {
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
        Physics2D.gravity = direction * GRAVITY * gravityScale;
        prevGravity = direction;

        SetVelocity(GetComponent<Rigidbody2D>());
    }
}
