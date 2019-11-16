using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlane_Spawn : MonoBehaviour
{
    public float spawnRateMin;
    public float spawnRateMax;
    public GameObject enemy_plane;

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
        else if(!GameManager.instance.isGameover)
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0;
                Instantiate(enemy_plane, transform.position, transform.rotation);
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            }
        }
        
    }
}
