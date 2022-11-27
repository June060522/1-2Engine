using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHp : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] CPlayManager cPlayManager;
    float maxHp;
    private void Awake()
    {
        maxHp = cPlayManager.Hp;
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = cPlayManager.Hp / maxHp;
    }
}
