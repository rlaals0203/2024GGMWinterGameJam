using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && 
            collision.transform.TryGetComponent(out IBlowable blowable))
        {
            if (blowable.RigidCompo.velocity.magnitude < 30)
            {
                blowable.RigidCompo.velocity *= 1.7f;
            }
            else
                blowable.RigidCompo.velocity *= 1.3f;

            BackgroundEffector.Instance.ChangeBackgroundColor(new Color(0, 100, 50) / 75, 0.4f);
            gameObject.SetActive(false);
        }
    }
}
