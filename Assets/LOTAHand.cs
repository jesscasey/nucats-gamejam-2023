using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOTAHand : MonoBehaviour
{
    [SerializeField] Sprite _openHandSprite;
    enum HandState { OPEN,CLOSED}
    HandState _handState = HandState.CLOSED;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_handState)
        {
            case HandState.CLOSED:
                UpdateClosedHand();
                break;
            case HandState.OPEN:
                break;
        }
    }
    void UpdateClosedHand()
    {
        transform.Translate(Vector3.down * Time.deltaTime * GameManager.speedUpModifier);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * .5f);
            if (transform.position.y >= -1)
            {
                OpenHand();
                GameManager.winMinigame();
            }
        }
    }

    void OpenHand()
    {
        _handState = HandState.OPEN;
        GetComponent<SpriteRenderer>().sprite = _openHandSprite;
    }
}
