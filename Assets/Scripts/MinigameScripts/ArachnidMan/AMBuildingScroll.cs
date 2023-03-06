using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMBuildingScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * GameManager.speedUpModifier * 3f);
        if(transform.position.y <= -11.25)
        {
            transform.position = new Vector3(0, 11.25f, 0);
        }
    }
}
