using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMPeonController : MonoBehaviour
{
    void Update()
    {
        MovePeon();
    }

    private void MovePeon()
    {
        float speed = Time.deltaTime * GameManager.speedUpModifier;
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

        Vector3 posChange = speed * inputs * 12;
        if (transform.position.x + posChange.x <= 8.75 && transform.position.x + posChange.x >= -5)
        {
            transform.Translate(Vector3.Scale(Vector3.right, posChange), Space.World);
        }
        if (Mathf.Abs(transform.position.y + posChange.y) <= 4.5)
        {
            transform.Translate(Vector3.Scale(Vector3.up, posChange), Space.World);
        }
    }
}
