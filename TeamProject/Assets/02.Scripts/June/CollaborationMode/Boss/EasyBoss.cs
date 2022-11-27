using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EasyBoss : BossManager
{
    private void Start()
    {
        x = transform.position.x;
        StartCoroutine(PatternStart());
    }
    void Update()
    {
        if (Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Clear!!");
            SceneManager.LoadScene("EndScene");
        }

        if (cLPlayer.Hp <= 0 && cRPlayer.Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Fail.....");
            SceneManager.LoadScene("EndScene");
        }

        if (x > transform.position.x && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }
        else if (x < transform.position.x && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }
        x = transform.position.x;

    }
    IEnumerator PatternStart()
    {
        while (true)
        {
            pattern = Random.Range(0, 2);

            switch (pattern)
            {
                case 0:
                    float x = Random.Range(-8.5f, 8.5f);
                    float y = Random.Range(-4.5f, 4.5f);
                    transform.DOMove(new Vector2(x, y), 3f);
                    break;
                case 1:
                    float random = Random.Range(-360,360);
                    turnObject.Turning(random);
                    break;
            }

            yield return new WaitForSeconds(8f);
        }
    }
}
