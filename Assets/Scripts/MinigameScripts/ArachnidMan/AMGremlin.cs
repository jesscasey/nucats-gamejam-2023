using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMGremlin : MonoBehaviour
{
    bool _direction = false;
    float _bombTimer = 0;
    [SerializeField] GameObject _bombPrefab;

    void Update()
    {
        float speedUpDT = Time.deltaTime * GameManager.speedUpModifier;
        transform.Translate(5*Vector3.right * speedUpDT * (_direction ? 1 : -1));
        if (Mathf.Abs(transform.position.x) >= 4)
        {
            _direction = !_direction;
        }
        _bombTimer += speedUpDT;
        if (_bombTimer >= .8)
        {
            GameObject bomb = Instantiate(_bombPrefab, transform.position, Quaternion.identity);
            bomb.transform.parent = transform.parent;
            _bombTimer = Random.Range(-.1f, .5f);
        }
    }
}
