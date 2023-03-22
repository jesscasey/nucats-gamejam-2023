using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovieTape : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.beginMinigame += Destroy;
    }
    private void OnDisable()
    {
        GameManager.beginMinigame -= Destroy;
    }
    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
