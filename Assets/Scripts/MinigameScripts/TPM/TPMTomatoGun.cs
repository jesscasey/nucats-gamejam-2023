using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMTomatoGun : MonoBehaviour
{
    bool _direction = false;
    float _tomatoTimer = 0;
    [SerializeField] GameObject _tomatoPrefab;

    private void Start()
    {
        _direction = Random.Range(0, 2) == 1 ? true : false;
    }
    void Update()
    {
        float speedUpDT = Time.deltaTime * GameManager.speedUpModifier;
        if (transform.position.y >= 4)
        {
            _direction = false;
        }
        if (transform.position.y <= -4)
        {
            _direction = true;
        }
        transform.Translate(5 * Vector3.up * speedUpDT * (_direction ? 1 : -1));
        _tomatoTimer += speedUpDT;
        if (_tomatoTimer >= .8)
        {
            GameObject tomato = Instantiate(_tomatoPrefab, transform.position, Quaternion.identity);
            tomato.transform.parent = transform.parent;
            _tomatoTimer = Random.Range(-.1f, .5f);
        }
    }
}
