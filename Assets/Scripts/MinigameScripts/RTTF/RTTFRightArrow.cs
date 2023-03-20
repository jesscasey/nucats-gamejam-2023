using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFRightArrow : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    bool canTurn = true;
    float arrowTimer = 0f;
    bool turnedRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrowTimer += Time.deltaTime * GameManager.speedUpModifier;
        if (Input.GetKeyDown(KeyCode.D) && canTurn)
        {
            canTurn = false;
            turnedRight = true;
            sr.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && canTurn)
        {
            canTurn = false;
            turnedRight = false;
            sr.enabled = false;
        }
        if (arrowTimer >= 1.1f && !canTurn)
        {
            ReturnToTheFuture.turn(turnedRight);
            if (!turnedRight)
            {
                GameManager.loseMinigame();
            }
            Destroy(gameObject);
        }
        else if (arrowTimer >= 1.1f && canTurn)
        {
            GameManager.loseMinigame();
            Destroy(gameObject);
        }
    }
}
