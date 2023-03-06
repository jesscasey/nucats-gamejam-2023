using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMinigame : MonoBehaviour
{
    protected float _timer = 0; //How long has passed since the minigame started
    protected bool _isWon = false; //has the minigame been won yet
    protected bool _isLost = false; //has the minigame been lost yet
}
