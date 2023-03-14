using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOTAHand : MonoBehaviour
{
    [SerializeField] Sprite _openHandSprite;
    [SerializeField] GameObject _amuletPrefab;
    enum HandState { OPEN,CLOSED}
    HandState _handState = HandState.CLOSED;
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
            transform.Translate(Vector3.up * .8f);
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
        GameObject amulet = Instantiate(_amuletPrefab,new Vector3(0,1,0),Quaternion.identity);
        amulet.transform.parent = transform.parent;
        GetComponent<SpriteRenderer>().sprite = _openHandSprite;
    }
}
