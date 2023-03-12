using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFBackground : MonoBehaviour
{
    public bool isTurning = false;
    public bool right;
    bool isDriving = true;
    float timer;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        ReturnToTheFuture.turn += TurnBackground;
        GameManager.loseMinigame += StopDriving;
    }
    private void OnDisable()
    {
        ReturnToTheFuture.turn -= TurnBackground;
        GameManager.loseMinigame -= StopDriving;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDriving)
        {
            SetAnimSpeed(0);
            return;
        }

        if (isTurning)
        {
            timer += Time.deltaTime * GameManager.speedUpModifier;
            if (right)
            {
                transform.position = Vector3.left * 4;
            }
            else
            {
                transform.position = Vector3.right * 4;
            }
            if (timer >= .7)
            {
                timer = 0;
                transform.position = Vector3.zero;
                isTurning = false;
            }
        }


    }
    public void SetAnimSpeed(float speed)
    {
        animator.speed = speed;
    }

    void TurnBackground(bool isRight)
    {
        right = isRight;
        isTurning = true;
    }

    void StopDriving()
    {
        isDriving = false;
    }
}
