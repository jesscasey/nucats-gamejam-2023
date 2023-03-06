using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArachnidMan : BaseMinigame
{
    private void OnEnable()
    {
        GameManager.loseMinigame += Lose;
    }
    private void Start()
    {
        AudioSource music = GetComponent<AudioSource>();
        music.pitch = GameManager.speedUpModifier;
    }
    void Lose()
    {
        _isLost = true;
    }
    private void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        if (_timer >= 8f)
        {
            GameManager.endMinigame(!_isLost);
        }
    }

}
