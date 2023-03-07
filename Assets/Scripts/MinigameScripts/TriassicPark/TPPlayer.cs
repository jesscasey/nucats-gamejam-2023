using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject m_Camera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Camera.transform.position = new Vector2(transform.position.x + 10, transform.position.y);
        
        rb.velocity = new Vector2(GameManager.speedUpModifier*.5f, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
    }
}
