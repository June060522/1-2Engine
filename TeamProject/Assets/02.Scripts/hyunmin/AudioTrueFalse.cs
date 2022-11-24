using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrueFalse : MonoBehaviour
{
    public AudioSource BGMSource;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Onclick()
    {
       /* if (BGMSource.volume = 0)
        {
            spriteRenderer.sprite = sprites[0];
        }*/
    }
}
