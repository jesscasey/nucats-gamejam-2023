using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    TextMeshProUGUI _textComponent;
    // Start is called before the first frame update
    private void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameManager.winMinigame += UpdateTextDisplay;
    }
    private void OnDisable()
    {
        GameManager.winMinigame -= UpdateTextDisplay;
    }
    void UpdateTextDisplay()
    {
        _textComponent.text = "£" + GameManager.cashScore;
    }
}
