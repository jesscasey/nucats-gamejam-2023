using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTheFuture : BaseMinigame
{
    private void OnEnable()
    {
        GameManager.winMinigame += Win;
    }
    private void Start()
    {
        AudioSource music = GetComponent<AudioSource>();
        music.pitch = GameManager.speedUpModifier;
    }


    void Win()
    {
        _isWon = true;
    }
    private void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        if (_timer >= 8f)
        {
            GameManager.endMinigame(_isWon);
        }
    }
}
