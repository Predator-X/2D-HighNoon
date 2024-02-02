using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
    public Sprite[] sprites;
  
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Random.Range(-1, 1);

        if (sprites.Length !=0) { GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 15)]; }
    }
}
