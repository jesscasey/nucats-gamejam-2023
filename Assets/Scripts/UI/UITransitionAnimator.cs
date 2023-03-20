using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransitionAnimator : MonoBehaviour
{
    [SerializeField] Sprite _twoSprite;
    [SerializeField] Sprite _oneSprite;
    [SerializeField] Sprite _zeroSprite;
    [SerializeField] SpriteRenderer _sr;
    int currcount = 3;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        if (_timer > .5f)
        {
            _timer = 0f;
            currcount--;
            switch (currcount)
            {
                case 2:
                    _sr.sprite = _twoSprite;
                    break;
                case 1:
                    _sr.sprite = _oneSprite;
                    break;
                case 0:
                    _sr.sprite = _zeroSprite;
                    break;
                default:
                    break;
            }
        }
    }
}
