using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinder : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _blindPower;

    private GameObject _blind;
    private Bullet _bullet; 
    private Material _material;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _blind = collision.transform.Find("Blind").gameObject;
            _material = _blind.GetComponent<SpriteRenderer>().material;

            _material.SetFloat("_size", Mathf.Lerp(1f, _blindPower, 0.5f));
            StartCoroutine(BlindRoutine());
        }
    }

    private IEnumerator BlindRoutine()
    {
        yield return new WaitForSeconds(_duration);
        _material.SetFloat("_size", Mathf.Lerp(_blindPower, 1f, 0.5f));
    }
}
