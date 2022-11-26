using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winner : MonoBehaviour
{
    public TextMeshProUGUI _textMeshProUGUI;
    void Start()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        Win(PlayerPrefs.GetString("WinnerName","none"));
    }

    private void Win(string name)
    { 
        _textMeshProUGUI.text = name;
    }
}
