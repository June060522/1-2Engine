using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowHp : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Window window;
    private float maxHp;

    private void Awake()
    {
        hpSlider = GetComponent<Slider>();
        window = GetComponentInParent<Window>();
        maxHp = window.Hp;
    }

    private void Update()
    {
        hpSlider.value = window.Hp / maxHp;
    }
}
