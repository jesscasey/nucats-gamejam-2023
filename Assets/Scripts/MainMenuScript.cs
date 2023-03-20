using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject[] _popcorns;
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] Transform _playTextTransform;
    [SerializeField] Transform _optionsTextTransform;
    [SerializeField] AudioSource _as;

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
        SceneManager.LoadScene(2); //load main game scene, change to load slower and have COOL effect
    }

    void OpenOptions()
    {
        _optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
