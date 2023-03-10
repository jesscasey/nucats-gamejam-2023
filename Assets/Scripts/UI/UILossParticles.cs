using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILossParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameManager.loseMinigame += EmitParticles;
    }
    private void OnDisable()
    {
        GameManager.loseMinigame -= EmitParticles;
    }
    void EmitParticles()
    {
        _ps.Play();
    }
}
