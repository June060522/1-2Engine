using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowHp : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    private float maxHp;

    private void Awake()
    {
        hpSlider = GetComponent<Slider>();
        maxHp = Window.Instance.Hp;
    }

    private void Update()
    {
        hpSlider.value = Window.Instance.Hp / maxHp;
    }
}
