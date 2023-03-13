using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFRift : MonoBehaviour
{
    public int riftDirection = 1;
    float riftTimer = 0f;
    bool isLost;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        ReturnToTheFuture.turn += Turn;
        GameManager.loseMinigame += GameLost;
    }
    private void OnDisable()
    {
        ReturnToTheFuture.turn -= Turn;
        GameManager.loseMinigame -= GameLost;
    }

    // Update is called once per frame
    void Update()
    {
        riftTimer += Time.deltaTime * GameManager.speedUpModifier;
        if (isLost)
        {
            transform.localScale += Vector3.one * Time.deltaTime * GameManager.speedUpModifier * 3;
            transform.localEulerAngles += Vector3.forward * Time.deltaTime * GameManager.speedUpModifier * 180;
            return;
        }
        
        if (riftTimer >= 2f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * Time.deltaTime * GameManager.speedUpModifier * riftDirection * 2,Space.World);
        transform.localScale = Vector3.one * Mathf.InverseLerp(0, 1.4f, riftTimer);
        transform.localEulerAngles += Vector3.forward * Time.deltaTime * GameManager.speedUpModifier * 180;
    }

    void Turn(bool right)
    {
        if (right)
        {
            transform.Translate(Vector3.left * 4, Space.World);
        }
        else
        {
            transform.Translate(Vector3.right * 4, Space.World);
        }
        riftDirection *= 5;
    }

    void GameLost()
    {
        GetComponent<AudioSource>().Play();
        isLost = true;
    }
}
