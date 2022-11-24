using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleTime : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timeTxt;
    [SerializeField]float playTime = 300f;
    [SerializeField]LPlayer lPlayer;
    [SerializeField]RPlayer rPlayer;

    private void Awake()
    {
        timeTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(lPlayer.Hp > 0 && rPlayer.Hp > 0)
        {
            playTime -= Time.deltaTime;
        }
        timeTxt.text = $"남은 시간 : {Mathf.Round(playTime)}초";

        if(playTime <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
