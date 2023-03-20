using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    [SerializeField] Image _fadeOut;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _fadeOut.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, _timer));
        if (_timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
