using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScrollerScript : MonoBehaviour
{
    [SerializeField] RectTransform _rt;
    [SerializeField] Image _fadeOut;
    [SerializeField] AudioSource _music;
    bool storyOver = false;
    float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _rt.Translate(Vector3.up * Time.deltaTime * 2f);
        if (!storyOver)
        {
            if (_timer >= 15f)
            {
                storyOver = true;
                _timer = 0;
            }
        }
        else
        {
            if (_timer >= 1.3f)
            {
                SceneManager.LoadScene(1);
            }
            _fadeOut.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, _timer));
            _music.volume = Mathf.Lerp(.8f, 0, _timer);
            
        }
        
    }
}
