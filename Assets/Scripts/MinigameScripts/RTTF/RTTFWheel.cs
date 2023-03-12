using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFWheel : MonoBehaviour
{
    public bool isTurning = false;
    public bool right;
    bool isDriving = true;
    float timer;
    private void OnEnable()
    {
        ReturnToTheFuture.turn += TurnBackground;
    }
    private void OnDisable()
    {
        ReturnToTheFuture.turn -= TurnBackground;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDriving)
        {
            return;
        }

        if (isTurning)
        {
            timer += Time.deltaTime * GameManager.speedUpModifier;
            if (right)
            {
                transform.eulerAngles = Vector3.forward * -45;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * 45;
            }
            if (timer >= .7)
            {
                timer = 0;
                transform.eulerAngles = Vector3.zero;
                isTurning = false;
            }
        }


    }
    void TurnBackground(bool isRight)
    {
        right = isRight;
        isTurning = true;
    }
}
