using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCT : MonoBehaviour {

    public GameObject fruitOBJ;
    public GameObject deleteWall;
    public Transform makePos;

    bool isStart = false;

    private void Start()
    {
        StartCoroutine(MakeFruit());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            deleteWall.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            deleteWall.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public IEnumerator MakeFruit()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            GameObject tempOBJ = Instantiate(fruitOBJ);
            tempOBJ.transform.position = new Vector3(Random.Range(-9, 9), makePos.transform.position.y, 0);
            yield return new WaitForSeconds(Random.Range(1.0f,5.0f)/5.0f);
        }
	    
    }
}
