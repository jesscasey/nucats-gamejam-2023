using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTTFSpeedPointer : MonoBehaviour
{
    float _timer = 0f;
    Vector3 _at89Angle = new Vector3(0, 0, -240f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        transform.localEulerAngles = _at89Angle * Mathf.InverseLerp(0, 3.7f,_timer);
    }
}
