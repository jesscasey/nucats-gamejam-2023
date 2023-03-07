using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILivesMask : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private void OnEnable()
    {
        GameManager.loseMinigame += UpdateAnimatorLives;
    }
    private void OnDisable()
    {
        GameManager.loseMinigame -= UpdateAnimatorLives;
    }

    void UpdateAnimatorLives()
    {
        _animator.SetInteger("Lives", GameManager.lives);
    }
}
