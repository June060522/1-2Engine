using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RPlayer : PlayerManager
{
    void Update()
    {
        InBrokenWindow();

        if (!isMove && Hp > 0)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                nowIndex++;
                if (nowIndex > window.Length - 1)
                    nowIndex = 0;

                StartCoroutine(MoveFloor());
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                nowIndex--;
                if (nowIndex < 0)
                    nowIndex = window.Length - 1;

                StartCoroutine(MoveFloor());
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spawnIndex++;
                if (spawnIndex > birds.Length - 1)
                    spawnIndex = 0;
            }

            if (Input.GetKeyDown(KeyCode.RightShift) && nowSpawn < maxSpawn && 
            SpawnCol.Instance.RplayerNowSpawnCool[spawnIndex] > SpawnCol.Instance.RplayerSpawnCool[spawnIndex])
            {
                SpawnCol.Instance.RplayerNowSpawnCool[spawnIndex] = 0;
                birdSize = showBird[spawnIndex].GetComponent<ChageShowScale>().birdType;
                Summon(Team.right, birds[spawnIndex], new Vector2(transform.position.x-0.5f, transform.position.y - 0.7f),Quaternion.Euler(0,180,0),birdSize);
                nowSpawn++;
            }
            if(BirdFood < maxFood)
            {
                SetPlusBirdFood(plusBirdFood);
            }
        }

        if(Input.GetKeyDown(KeyCode.O))
            Hp -=1;
        if(Hp <= 0 && !GameOver)
        {
            GameOver = true;
            PlayerPrefs.SetString("WinnerName",PlayerPrefs.GetString("LPlayerName"));
            transform.GetComponent<SpriteRenderer>().sortingOrder = 999;
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 180, -16), 0.3f)
            .OnComplete(() => transform.DOMoveY(-7,2f)
            .OnComplete(()=>SceneManager.LoadScene("EndScene"))));
        }
    }

    IEnumerator MoveFloor()
    {
        isMove = true;
        DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 0, 0), 0.3f))
        .OnComplete(() => DOTween.Sequence().Append(transform.DOMove(new Vector3(transform.position.x + 1f, transform.position.y), 0.5f)));
        yield return new WaitForSeconds(0.8f);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.position = new Vector3(transform.position.x, window[nowIndex].transform.position.y + 0.7f);
        transform.DOMove(new Vector3(transform.position.x - 1f, transform.position.y), 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return isMove = false;
    }
}
