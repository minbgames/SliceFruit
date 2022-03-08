using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_RightCT : MonoBehaviour {

    public Sprite[] fruitSP;
    public SpriteRenderer fruitSR;
    [HideInInspector]
    public int fruitNumber = 0;

    private void Start()
    {
        fruitSR.sprite = fruitSP[fruitNumber];
    }

    public void justDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.gameObject.CompareTag("End"))
        {
            justDead();
        }
    }
}
