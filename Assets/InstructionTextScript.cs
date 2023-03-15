using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionTextScript : MonoBehaviour
{
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        if (_timer >= .5)
        {
            Destroy(gameObject);
        }
    }
}
