using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state
{
    alive = 1,
    broken = 2
}
public class Window : Singleton<Window>
{
    public float Hp;

    public void Damage(float damage)
    {
        StartCoroutine(OnDamage(damage));
        if(damage <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator OnDamage(float damage)
    {
        float returnDamage = 0;
        float yieldDamage = 0;
        while(returnDamage <= damage)
        {
            yieldDamage = 0.1f;
            Hp -= yieldDamage;
            returnDamage += yieldDamage;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
