using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject[] _popcorns;
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] Image _fadeOut;
    [SerializeField] Transform _playTextTransform;
    [SerializeField] Transform _optionsTextTransform;
    [SerializeField] AudioSource _as;
    [SerializeField] AudioSource _music;
    float _timer = 0;
    bool _beginGame = false;

    int _currentOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject popcorn in _popcorns)
        {
            popcorn.transform.position = new Vector3(popcorn.transform.position.x,_playTextTransform.position.y, popcorn.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_beginGame)
        {
            _timer += 2*Time.deltaTime;
            if (_timer >= 1.3f)
            {
                SceneManager.LoadScene(2);
            }
            _fadeOut.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, _timer));
            _music.volume = Mathf.Lerp(.8f, 0, _timer);
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentOption -= 1;
            _as.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentOption += 1;
            _as.Play();
        }
        _currentOption = _currentOption % 2;
        foreach (GameObject popcorn in _popcorns)
        {
            if (_currentOption == 0)
                popcorn.transform.position = new Vector3(popcorn.transform.position.x, _playTextTransform.position.y, popcorn.transform.position.z);
            else popcorn.transform.position = new Vector3(popcorn.transform.position.x, _optionsTextTransform.position.y, popcorn.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_currentOption)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    OpenOptions();
                    break;
            }
        }

    }

    void StartGame()
    {
        _beginGame = true; //load main game scene, change to load slower and have COOL effect
    }

    void OpenOptions()
    {
        _optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
