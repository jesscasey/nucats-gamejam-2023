using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMusicSpeedup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().pitch = GameManager.speedUpModifier;
    }
}
