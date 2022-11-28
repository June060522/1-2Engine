using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class VillainyBoss : BossManager
{
    private void Start()
    {
        x = transform.position.x;
    }
    private void OnEnable()
    {
        transform.DOMove(new Vector3(5.51f,-0.46f),3f)
        .OnComplete(() => StartCoroutine(PatternStart()));
    }
    void Update()
    {
        if (Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Easy Stage Clear!!");
            SceneManager.LoadScene("EndScene");
        }

        if (cLPlayer.Hp <= 0 && cRPlayer.Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Easy Stage Fail..");
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
    IEnumerator PatternStart()
    {
        while (true)
        {
            pattern = Random.Range(0, 5);
            float index = Random.Range(0, 2);
            if (index == 0)
            {
                try
                {
                    target = GameObject.Find("LPlayer");
                }
                catch
                {
                    target = GameObject.Find("RPlayer");
                }
            }
            else
            {
                try
                {
                    target = GameObject.Find("RPlayer");
                }
                catch
                {
                    target = GameObject.Find("LPlayer");
                }
            }
            float random = Random.Range(-360, 360);
            turnObject.Turning(random);
            switch (pattern)
            {
                case 0:
                    float x = Random.Range(target.transform.position.x > -8.5 ? target.transform.position.x : -8.5f
                    , target.transform.position.x < 8.5 ? target.transform.position.x : 8.5f);
                    float y = Random.Range(target.transform.position.y > -4.5 ? target.transform.position.y : -4.5f
                    , target.transform.position.y > -4.5 ? target.transform.position.y : -4.5f);
                    transform.DOMove(new Vector2(x, y), 2f);
                    for (int i = -120; i <= 120; i += 60)
                        PoolManager.Instance.Pop(attack, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + i));
                    break;
                case 1:
                    cLPlayer.w = KeyCode.S;
                    cLPlayer.s = KeyCode.W;
                    cLPlayer.a = KeyCode.D;
                    cLPlayer.d = KeyCode.A;
                    cRPlayer.up = KeyCode.DownArrow;
                    cRPlayer.down = KeyCode.UpArrow;
                    cRPlayer.left = KeyCode.RightArrow;
                    cRPlayer.right = KeyCode.LeftArrow;
                    yield return new WaitForSeconds(3f);
                    cLPlayer.w = KeyCode.W;
                    cLPlayer.s = KeyCode.S;
                    cLPlayer.a = KeyCode.A;
                    cLPlayer.d = KeyCode.D;
                    cRPlayer.up = KeyCode.UpArrow;
                    cRPlayer.down = KeyCode.DownArrow;
                    cRPlayer.left = KeyCode.LeftArrow;
                    cRPlayer.right = KeyCode.RightArrow;
                    break;
                case 2:
                    time = 0;
                    while (time < 3)
                    {
                        time += Time.deltaTime;
                        Vector2 dir = target.transform.position - transform.position;
                        transform.Translate(dir.normalized * Time.deltaTime);
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
                case 3:
                    for (int i = 0; i <= 360; i += 45)
                        PoolManager.Instance.Pop(attack, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + i));
                    yield return new WaitForSeconds(1f);
                    for (int i = 0; i <= 360; i += 45)
                        PoolManager.Instance.Pop(attack, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + i + 22.5f));
                    break;
                case 4:
                    turnObject.Turning(360f);
                    yield return new WaitForSeconds(1.5f);
                    float sapwnindex = Random.Range(0, 4);
                    switch (sapwnindex)
                    {
                        case 0:
                            for (int i = -2; i <= 2; i++)
                                PoolManager.Instance.Pop(attack, new Vector3(8.5f,4.5f + i), Quaternion.Euler(0, 0, -45));
                            break;
                        case 1:
                            for (int i = -2; i < 2; i++)
                                PoolManager.Instance.Pop(attack, new Vector3(-8.5f,4.5f + i), Quaternion.Euler(0, 0, 45));
                            break;
                        case 2:
                            for (int i = -2; i < 2; i++)
                                PoolManager.Instance.Pop(attack, new Vector3(8.5f,-4.5f + i), Quaternion.Euler(0, 0, -115));
                            break;
                        case 3:
                            for (int i = -2; i < 2; i++)
                                PoolManager.Instance.Pop(attack, new Vector3(-8.5f,-4.5f + i), Quaternion.Euler(0, 0, 115));
                            break;
                    }
                    break;
            }

            yield return new WaitForSeconds(4f);
        }
    }
}
