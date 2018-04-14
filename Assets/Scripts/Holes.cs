using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour, IBreakable {

    [SerializeField]
    GameObject holeGraphic;

    [SerializeField]
    GameObject[] spawnAreas = new GameObject[12];

    [SerializeField]
    float timer;

    void Awake()
    {
        int i = 0;
        foreach (Transform item in this.transform)
        {
            spawnAreas[i] = item.gameObject;
            i++;
        }
    }

	// Use this for initialization
	void Start () {

       
        


        //holeGraphic.GetComponent<BoxCollider2D>().isTrigger = true;
	}


    public void Break()
    {
        int randomNumber;
        randomNumber = Random.Range(0, spawnAreas.Length / 2);
        SpawnHole(randomNumber);

    }

    private void SpawnHole(int number)
    {
        int spawnArea = number * 2;
        float xPos = Random.Range(spawnAreas[spawnArea].transform.position.x, spawnAreas[spawnArea+1].transform.position.x);
        float yPos = Random.Range(spawnAreas[spawnArea].transform.position.y, spawnAreas[spawnArea + 1].transform.position.y);
        Vector2 spawnPos = new Vector2(xPos,yPos);
        Instantiate(holeGraphic, spawnPos, holeGraphic.transform.rotation);
    }





}
