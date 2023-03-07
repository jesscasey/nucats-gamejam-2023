using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMCityScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * GameManager.speedUpModifier*.5f);
    }
}
