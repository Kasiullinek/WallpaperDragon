using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefab;
    public GameObject EnemyPrefab;

    private float max = 8;
    private float min = -8;
    private float xRange = 18;
    private float zRange = -1;

    private GameManager gameManagerS;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerS = GameObject.Find("GameManager").GetComponent<GameManager>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateRandomPosition()
    {
        float randomY = Random.Range(min, max + 1);
        Vector3 randPosition = new Vector3(xRange, randomY, zRange);
        return randPosition;
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, GenerateRandomPosition(), EnemyPrefab.transform.rotation);
    }

    int GenerateIndex()
    {
        int index = Random.Range(0, ballPrefab.Length);
        return index;
    }
    
    public void SpawnBall()
    {
        int index = GenerateIndex();
        Instantiate (ballPrefab[index], GenerateRandomPosition(), ballPrefab[index].transform.rotation);
    }
}
