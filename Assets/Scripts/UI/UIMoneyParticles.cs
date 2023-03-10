using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoneyParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;
    private void OnEnable()
    {
        GameManager.endMinigame += EmitParticles;
    }
    private void OnDisable()
    {
        GameManager.endMinigame -= EmitParticles;
    }
    void EmitParticles(bool isWon)
    {
        if(isWon) _ps.Play();

    }
}
