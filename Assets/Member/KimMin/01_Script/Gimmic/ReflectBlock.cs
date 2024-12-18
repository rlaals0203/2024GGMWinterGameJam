using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            if (WindController.Instance.isHorizontal)
            {
                float velocity = bullet.RigidCompo.velocity.x;
                bullet.moveDir = Vector2.up;
                WindController.Instance.UpWind();

                bullet.RigidCompo.AddForce(bullet.moveDir * velocity);

                WindController.Instance.isHorizontal = false;
            }
            else
            {
                float velocity = bullet.RigidCompo.velocity.x;
                bullet.moveDir = Vector2.right;
                WindController.Instance.RightWind();

                bullet.RigidCompo.AddForce(bullet.moveDir * velocity);

                WindController.Instance.isHorizontal = true;
            }
        }
    }
}
