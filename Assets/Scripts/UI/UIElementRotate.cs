using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIElementRotate : MonoBehaviour
{
    float _timer;
    const float tau = Mathf.PI * 2;
    // Update is called once per frame
    private void OnEnable()
    {
        GameManager.endMinigame += SyncTimer;
    }
    private void OnDisable()
    {
        GameManager.endMinigame -= SyncTimer;
    }
    void Update()
    { 
        //5 degree wobble, 20% scale increase
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        float sinTimer = Mathf.Sin(_timer * tau);
        float sinTimer2 = Mathf.Sin(_timer * tau * 2);
        transform.localEulerAngles = new Vector3(0, 0, 5 * sinTimer);
        transform.localScale = Vector3.one * (1 + .1f * sinTimer2);
    }

    void SyncTimer(bool isWon)
    {
        _timer = 0;
    }
}
