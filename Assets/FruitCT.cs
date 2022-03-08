using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCT : MonoBehaviour {

    public Sprite[] fruitSP;
    public SpriteRenderer fruitSR;
    public Rigidbody2D fruitRB2D;
    public GameObject leftPartOBJ;
    public GameObject rightPartOBJ;
    private int fruitNumber;

    private void Start()
    {
        fruitNumber = Random.Range(0, 15);
        fruitSR.sprite = fruitSP[fruitNumber];
        fruitRB2D.gravityScale = Random.Range(50, 180)/100.0f;
        fruitRB2D.AddTorque(Random.Range(10,200));
    }

    public void fruitDead()
    {
        GameObject leftPart = Instantiate(leftPartOBJ);
        GameObject rightPart = Instantiate(rightPartOBJ);
        leftPart.GetComponent<Part_LeftCT>().fruitNumber = fruitNumber;
        rightPart.GetComponent<Part_RightCT>().fruitNumber = fruitNumber;

        leftPart.transform.position = transform.position;
        rightPart.transform.position = transform.position;
        leftPart.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, -4), Random.Range(1, 8)), ForceMode2D.Impulse);
        rightPart.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1, 4), Random.Range(1, 8)), ForceMode2D.Impulse);
        leftPart.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-4.0f,-1.0f),ForceMode2D.Impulse);
        rightPart.GetComponent<Rigidbody2D>().AddTorque(Random.Range(1.0f, 4.0f), ForceMode2D.Impulse);
        Destroy(gameObject);
    }

    public void justDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.gameObject.CompareTag("enemy"))
        {
            fruitDead();
        }
        else if (_col.gameObject.CompareTag("End"))
        {
            justDead();
        }
    }
}
