using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBLaser : MonoBehaviour
{
    [SerializeField]LineRenderer _lr;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        if (_timer >= .1f)
        {
            Destroy(gameObject);
        }
    }
    public void SetPositions(Vector3 pos1, Vector3 pos2)
    {
        _lr.SetPosition(0, pos1);
        _lr.SetPosition(1, pos2);
    }
}
