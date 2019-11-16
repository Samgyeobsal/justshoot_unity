using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRocket_spawn : MonoBehaviour
{
    public float spawnRateMin;
    public float spawnRateMax;
    public GameObject rocket;
    public GameObject lazeritem;
    public GameObject[] bulletSpawns;
    
    private int whatspawnerspawn;
    public int Ivalue;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (GameManager.instance.isGameover)
        {
            spawnRate = 0;
        }
        if(Random.Range(1,101)<=Ivalue)
        {
            if (!GameManager.instance.isGameover)
            {
                if (timeAfterSpawn >= spawnRate)
                {
                    Instantiate(lazeritem, bulletSpawns[Random.Range(0, bulletSpawns.Length)].transform.position, Quaternion.identity);
                    timeAfterSpawn = 0;
                }
            }
        }
        else
        {
            if (!GameManager.instance.isGameover)
            {
                if (timeAfterSpawn >= spawnRate)
                {
                    Instantiate(rocket, bulletSpawns[Random.Range(0, bulletSpawns.Length)].transform.position, Quaternion.identity);
                    timeAfterSpawn = 0;
                }
            }
        }
    }
}
