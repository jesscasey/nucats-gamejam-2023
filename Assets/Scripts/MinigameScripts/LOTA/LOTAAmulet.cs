using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOTAAmulet : MonoBehaviour
{
    float _amuletTimer = 1f;
    [SerializeField] GameObject _splashParticles;
    void Start()
    {
        
    }
    void Update()
    {
        _amuletTimer -= Time.deltaTime * GameManager.speedUpModifier;
        transform.localScale = Vector3.one * _amuletTimer;
        if(transform.localScale.x <= .05f)
        {
            GameObject splash = Instantiate(_splashParticles,transform.position,Quaternion.identity);
            splash.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }
}
