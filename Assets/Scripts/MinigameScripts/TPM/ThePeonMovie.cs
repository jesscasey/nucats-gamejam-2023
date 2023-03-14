using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePeonMovie : BaseMinigame
{
    public bool gameIsLost = false;
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
        gameIsLost = true;
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
