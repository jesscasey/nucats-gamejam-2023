using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFLeftArrow : MonoBehaviour
{
    bool canTurn = true;
    float arrowTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrowTimer += Time.deltaTime * GameManager.speedUpModifier;
        if (Input.GetKeyDown(KeyCode.A) && canTurn)
        {
            canTurn = false;
            ReturnToTheFuture.turn(false);
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.D) && canTurn)
        {
            GameManager.loseMinigame();
            Destroy(gameObject);
        }
        if (arrowTimer >= 1.3f)
        {
            GameManager.loseMinigame();
            Destroy(gameObject);
        }
    }
}
