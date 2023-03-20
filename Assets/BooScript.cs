using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooScript : MonoBehaviour
{
    [SerializeField] AudioSource _as;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameManager.loseMinigame += Boo;
    }
    private void OnDisable()
    {
        GameManager.loseMinigame -= Boo;
    }
    void Boo()
    {
        _as.pitch = GameManager.speedUpModifier;
        _as.Play();
    }
}