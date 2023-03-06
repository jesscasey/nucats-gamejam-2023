using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMBomb : MonoBehaviour
{
    [SerializeField] GameObject _explosion;
    Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = .7f * GameManager.speedUpModifier;
    }
    void Update()
    {
        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(_explosion,transform.position,Quaternion.identity);
            explosion.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }
}
