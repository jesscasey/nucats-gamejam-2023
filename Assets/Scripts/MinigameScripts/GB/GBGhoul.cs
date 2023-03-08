using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBGhoul : MonoBehaviour
{
    float _timer;
    const float tau = Mathf.PI * 2;
    Vector3 _initPos;
    bool _isAlive = true;
    SpriteRenderer _sr;
    [SerializeField] GameObject _explosion;
    // Start is called before the first frame update
    void Start()
    {
        _initPos = transform.position;
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        switch (_isAlive)
        {
            case true:
                MoveGhoul();
                FadeGhoulIn();
                break;
            case false:
                FadeGhoulOut();
                break;
        }
        

    }

    void MoveGhoul()
    {
        float sinTimer = Mathf.Sin(_timer * tau*.5f);
        float sinTimer2 = Mathf.Sin(_timer * tau);
        Vector3 movePos = new Vector3(_initPos.x + sinTimer * 4, _initPos.y + sinTimer2, _initPos.z);
        transform.position = movePos;
    }
    void FadeGhoulIn()
    {
        float newAlpha = _timer;
        _sr.color = new Vector4(1,1,1,newAlpha);
    }
    void FadeGhoulOut()
    {
        float newAlpha = Mathf.Lerp(1, 0, _timer);
        _sr.color = new Vector4(1, 1, 1, newAlpha);
        transform.position += Vector3.down * Time.deltaTime * GameManager.speedUpModifier;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isAlive)
        {
            return;
        }
        Debug.Log("COLLISION)");
        _isAlive = false;
        _timer = 0f;
        GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        explosion.transform.parent = transform.parent;
        transform.parent.GetComponent<Ghoulbusters>().ghoulsKilled += 1;
    }
}
