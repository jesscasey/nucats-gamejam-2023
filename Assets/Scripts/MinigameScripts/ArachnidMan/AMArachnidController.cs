using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMArachnidController : MonoBehaviour
{
    bool _alive = true;
    AudioSource _spiderWalk;

    private void Start()
    {
        _spiderWalk = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Hostile") && _alive)
        {
            GameManager.loseMinigame?.Invoke();
            _alive = false;
        }
    }

    private void Update()
    {
        if (_alive)
        {
            MoveArachnid();
        }
        else
        {
            transform.Translate(5 * Vector3.down * Time.deltaTime * GameManager.speedUpModifier,Space.World);
            transform.Rotate(360 * Vector3.forward * Time.deltaTime * GameManager.speedUpModifier);
        }
    }

    private void MoveArachnid()
    {
        float speed = Time.deltaTime * GameManager.speedUpModifier * 720;
        float angle;


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            return;
        }
        Vector3 inputs = new Vector3(0, 0, 0);
        inputs[0] += Input.GetKey(KeyCode.A) ? -1 : 0;
        inputs[0] += Input.GetKey(KeyCode.D) ? 1 : 0;
        inputs[1] += Input.GetKey(KeyCode.S) ? -1 : 0;
        inputs[1] += Input.GetKey(KeyCode.W) ? 1 : 0;
        inputs = inputs.normalized;

        Vector3 posChange = Time.deltaTime * GameManager.speedUpModifier * inputs * 5;
        if(Mathf.Abs(transform.position.x + posChange.x) <=3.5)
        {
            transform.Translate(Vector3.Scale(Vector3.right, posChange),Space.World);
        }
        if (Mathf.Abs(transform.position.y + posChange.y) <= 5)
        {
            transform.Translate(Vector3.Scale(Vector3.up, posChange), Space.World);
        }
        angle = Mathf.Atan2(inputs[1], inputs[0]) * Mathf.Rad2Deg -90;
        RotateArachnid(angle, speed);

        if (!_spiderWalk.isPlaying)
        {
            _spiderWalk.Play();
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void RotateArachnid(float angle, float speed)
    {
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);
    }
}
