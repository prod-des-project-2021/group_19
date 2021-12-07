using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBeh : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public Sprite[] images = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, images.Length);
        spriteRenderer.sprite = images[num];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
