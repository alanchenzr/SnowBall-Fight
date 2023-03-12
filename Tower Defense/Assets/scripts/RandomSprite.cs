using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    private int rand;
    public Sprite[] Sprite_Variations;

    // Start is called before the first frame update
    void Start()
    {
        rand = (int) Mathf.Repeat(transform.position.x*16, Sprite_Variations.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Variations[rand];
    }
}
