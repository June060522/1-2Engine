using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBossHp : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] BossManager bossManager;
    float maxHp;
    private void Awake()
    {
        maxHp = bossManager.Hp;
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = bossManager.Hp / maxHp;
    }
}
