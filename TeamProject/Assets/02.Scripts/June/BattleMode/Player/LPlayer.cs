using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LPlayer : PlayerManager
{
    void Update()
    {
        InBrokenWindow();

        if(!isMove && Hp > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                nowIndex++;
                if (nowIndex > window.Length - 1)
                    nowIndex = 0;
                StartCoroutine(MoveFloor());
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                nowIndex--;
                if (nowIndex < 0)
                    nowIndex = window.Length - 1;
                StartCoroutine(MoveFloor());
                DOTween.Kill(transform,true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                spawnIndex++;
                if (spawnIndex > birds.Length - 1)
                    spawnIndex = 0;
            }
            if(Input.GetKeyDown(KeyCode.Space) && nowSpawn < maxSpawn &&
            SpawnCol.Instance.LplayerNowSpawnCool[spawnIndex] > SpawnCol.Instance.LplayerSpawnCool[spawnIndex])
            {
                birdSize = showBird[spawnIndex].GetComponent<ChageShowScale>().birdType;
                Summon(Team.left,birds[spawnIndex],new Vector2(transform.position.x + 0.5f,transform.position.y - 0.7f),Quaternion.identity,birdSize);
            }

            if(BirdFood < maxFood)
            {
                SetPlusBirdFood(plusBirdFood);
            }
        }

        if(Hp <= 0 && !GameOver)
        {
            GameOver = true;
            PlayerPrefs.SetString("WinnerName",PlayerPrefs.GetString("RPlayerName")+ " Win!!");
            transform.GetComponent<SpriteRenderer>().sortingOrder = 999;
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 0, -16), 0.3f)
            .OnComplete(() => transform.DOMoveY(-7,2f)
            .OnComplete(()=>SceneManager.LoadScene("EndScene"))));
        }
    }

    IEnumerator MoveFloor()
    {
        isMove = true;
        DOTween.Kill(transform);
        DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 180, 0), 0.3f)
        .OnComplete(() => DOTween.Sequence().Append(transform.DOMoveX(transform.position.x - 1f, 0.5f))));
        yield return new WaitForSeconds(1f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, window[nowIndex].transform.position.y + 0.7f);
        transform.DOMoveX(transform.position.x +1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return isMove = false;
    }
}
