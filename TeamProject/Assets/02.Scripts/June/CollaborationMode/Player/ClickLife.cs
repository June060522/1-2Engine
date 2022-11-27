using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickLife : MonoBehaviour
{
    [SerializeField] Team team = Team.right;
    [SerializeField] Slider slider;
    [SerializeField] CPlayManager cPlayManager;
    private float nowClick = 0;
    private float maxClick = 100;
    private GameObject rplayer;
    private GameObject lplayer;
    private void Awake()
    {
        rplayer = GameObject.Find("RPlayer");
        lplayer = GameObject.Find("LPlayer");
    }
    private void Update()
    {

        if ((cPlayManager.Hp <= 0 && team == Team.right && Input.GetKeyDown(KeyCode.RightShift)) ||
        (cPlayManager.Hp <= 0 && team == Team.left && Input.GetKeyDown(KeyCode.Space)))
        {
            nowClick++;
            if (nowClick >= maxClick)
            {
                nowClick = 0;
                if (team == Team.right)
                {
                    rplayer.SetActive(true);
                    rplayer.GetComponent<CPlayManager>().Hp = 40;
                }
                else
                {
                    lplayer.SetActive(true);
                    lplayer.GetComponent<CPlayManager>().Hp = 40;
                }
            }
        }
        slider.value = nowClick / maxClick;
    }
}
