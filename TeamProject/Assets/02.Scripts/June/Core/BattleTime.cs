using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BattleTime : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timeTxt;
    [SerializeField]TextMeshProUGUI showTxt;
    [SerializeField]float playTime = 300f;
    [SerializeField]LPlayer lPlayer;
    [SerializeField]RPlayer rPlayer;

    private bool oneTime = false;
    private bool twoTime = false;

    private void Awake()
    {
        timeTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            playTime -= 15f;
        if(lPlayer.Hp > 0 && rPlayer.Hp > 0)
        {
            playTime -= Time.deltaTime;
        }
        timeTxt.text = $"남은 시간 : {Mathf.Round(playTime)}초";

        if(playTime <= 0)
        {
            if(lPlayer.Hp > rPlayer.Hp)
            {
                PlayerPrefs.SetString("WinnerName",PlayerPrefs.GetString("LPlayerName")+ " Win!!");
            }
            else if(lPlayer.Hp < rPlayer.Hp)
            {
                PlayerPrefs.SetString("WinnerName",PlayerPrefs.GetString("RPlayerName")+ " Win!!");
            }
            else if((lPlayer.Hp == rPlayer.Hp))
            {
                PlayerPrefs.SetString("WinnerName","Drew");
            }
            SceneManager.LoadScene("EndScene");
        }

        if(!oneTime && playTime < 200)
        {
            showTxt.DOFade(255,0.1f);
            showTxt.DOFade(0,2f);
            lPlayer.PlusBirdFood *= 2;
            rPlayer.PlusBirdFood *= 2;
            oneTime = true;
        }
        else if(!twoTime && playTime < 100)
        {
            showTxt.DOFade(255,0.1f);
            showTxt.DOFade(0,2f);
            lPlayer.PlusBirdFood *= 2;
            rPlayer.PlusBirdFood *= 2;
            twoTime = true;
        }
    }
}
