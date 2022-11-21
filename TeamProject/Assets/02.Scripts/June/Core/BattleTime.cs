using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTime : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timeTxt;
    [SerializeField]float playTime = 300f;

    private void Awake()
    {
        timeTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        playTime -= Time.deltaTime;
        timeTxt.text = $"남은 시간 : {Mathf.Round(playTime)}초";
    }
}
