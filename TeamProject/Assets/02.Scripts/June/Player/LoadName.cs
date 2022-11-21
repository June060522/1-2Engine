using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadName : MonoBehaviour
{
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] TextMeshProUGUI nameTxt;
    private void Awake()
    {
        nameTxt = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if (playerName == PlayerName.Lplayer)
        {
            nameTxt.text = PlayerPrefs.GetString("LPlayerName");
        }
        else if (playerName == PlayerName.Rplayer)
        {
            nameTxt.text = PlayerPrefs.GetString("RPlayerName");
        }
    }
}
