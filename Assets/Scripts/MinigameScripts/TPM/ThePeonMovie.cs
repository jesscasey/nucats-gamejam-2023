using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePeonMovie : BaseMinigame
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

        if (_timer >= 4f)
        {
            GameManager.endMinigame(!_isLost);
        }
    }
}
