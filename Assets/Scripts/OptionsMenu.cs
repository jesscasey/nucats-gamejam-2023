using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer soundEffectsMixer;
    public AudioMixer musicMixer;
    [SerializeField] AudioSource _as;

    public Slider soundEffectsSlider;
    public Slider musicSlider;
    [SerializeField] GameObject _popcorn;
    [SerializeField] GameObject _mainMenu;
    [SerializeField] Transform _musicTextTransform;
    [SerializeField] Transform _soundTextTransform;
    [SerializeField] Transform _exitTextTransform;

    int _currentOption = 0;



    public void SetSoundEffectVolume(float volume)
    {
        soundEffectsMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }    

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    // Start is called before the first frame update
    void Start()
    {
            _popcorn.transform.position = new Vector3(_popcorn.transform.position.x, _musicTextTransform.position.y, _popcorn.transform.position.z);
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
        if (_currentOption < 0)
        {
            _currentOption = 2;
        }
        if (_currentOption > 2)
        {
            _currentOption = 0;
        }
        if (_currentOption == 0)
        {
            _popcorn.transform.position = new Vector3(_popcorn.transform.position.x, _musicTextTransform.position.y, _popcorn.transform.position.z);
        }
        else if (_currentOption == 1)
        {
            _popcorn.transform.position = new Vector3(_popcorn.transform.position.x, _soundTextTransform.position.y, _popcorn.transform.position.z);
        }
        else
        {
            _popcorn.transform.position = new Vector3(_popcorn.transform.position.x, _exitTextTransform.position.y, _popcorn.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_currentOption)
            {
                case 2:
                    CloseOptions();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            switch (_currentOption)
            {
                case 0:
                    musicSlider.value += .1f;
                    break;
                case 1:
                    soundEffectsSlider.value += .1f;
                    _as.Play();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (_currentOption)
            {
                case 0:
                    musicSlider.value -= .1f;
                    break;
                case 1:
                    soundEffectsSlider.value -= .1f;
                    _as.Play();
                    break;
            }
        }

    }

    void CloseOptions()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

}
