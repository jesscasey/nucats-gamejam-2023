using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMTomato : MonoBehaviour
{
    [SerializeField] GameObject _splat;
    Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * GameManager.speedUpModifier*10, Space.World);
        transform.Rotate(Vector3.forward * Time.deltaTime * 180);
        if (transform.position.x >=8.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
