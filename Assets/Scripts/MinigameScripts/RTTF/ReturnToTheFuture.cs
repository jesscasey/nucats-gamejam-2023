using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTheFuture : BaseMinigame
{
    [SerializeField] RTTFBackground _background;
    [SerializeField] Transform _arrowPoint;
    [SerializeField] GameObject _leftArrow;
    [SerializeField] GameObject _rightArrow;
    public delegate void Turn(bool right);
    public static Turn turn;
    int _arrowsCreated = 0;

    bool isTurning;
    private void OnEnable()
    {
        GameManager.loseMinigame += Lose;
    }
    private void Start()
    {
        AudioSource music = GetComponent<AudioSource>();
        music.pitch = GameManager.speedUpModifier;
    }


    void Lose()
    {
        _isLost = true;
    }
    private void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        
        if (_timer >= 4f)
        {
            GameManager.endMinigame(!_isLost);
        }
        if (_isLost)
        {
            return;
        }
        _background.SetAnimSpeed(_timer * .2f +.3f);
        if (_timer>.3f && _arrowsCreated == 0)
        {
            _arrowsCreated++;
           if(Random.Range(0, 2) == 0)
            {
                GameObject arrow = Instantiate(_leftArrow, _arrowPoint);
                arrow.transform.position = _arrowPoint.transform.position;
            }
            else
            {
                GameObject arrow = Instantiate(_rightArrow, _arrowPoint);
                arrow.transform.position = _arrowPoint.transform.position;
            }
        }
        if (_timer > 2.3f && _arrowsCreated == 1)
        {
            _arrowsCreated++;
            if (Random.Range(0, 2) == 0)
            {
                GameObject arrow = Instantiate(_leftArrow, _arrowPoint);
                arrow.transform.position = _arrowPoint.transform.position;
            }
            else
            {
                GameObject arrow = Instantiate(_rightArrow, _arrowPoint);
                arrow.transform.position = _arrowPoint.transform.position;
            }
        }
    }
}
