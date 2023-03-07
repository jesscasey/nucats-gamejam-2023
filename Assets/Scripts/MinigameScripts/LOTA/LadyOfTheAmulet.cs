using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyOfTheAmulet : BaseMinigame
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
        if (_timer >= 4f)
        {
            GameManager.endMinigame(_isWon);
        }
    }

}
