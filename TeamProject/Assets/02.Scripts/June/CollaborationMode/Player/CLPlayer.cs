using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLPlayer : CPlayManager
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.5f,8.5f),Mathf.Clamp(transform.position.y,-4.5f,4.5f));

        if(transform.position.y >= 4.5f)
        {
            Hp -= 0.1f;
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(Vector2.down * JumpPower);
        }
        else if(transform.position.y <= -4.5f)
        {
            Hp -= 0.1f;
            rb2D.gravityScale = 0f;
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(Vector2.up * JumpPower * 8);
            rb2D.gravityScale = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2D.AddForce(Vector2.up * JumpPower,ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PoolManager.Instance.Pop(throwFood,transform.position,Quaternion.identity);
        }

        if(Hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
