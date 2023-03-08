using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBCrosshair : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
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

        Vector3 posChange = speed * inputs * 8;
        if (Mathf.Abs(transform.position.x + posChange.x) <= 8.75)
        {
            transform.Translate(Vector3.Scale(Vector3.right, posChange), Space.World);
        }
        if (Mathf.Abs(transform.position.y + posChange.y) <= 5)
        {
            transform.Translate(Vector3.Scale(Vector3.up, posChange), Space.World);
        }
    }
}
