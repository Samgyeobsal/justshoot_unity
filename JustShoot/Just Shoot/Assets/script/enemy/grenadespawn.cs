using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadespawn : MonoBehaviour
{
    public GameObject grenadepre;
    public GameObject bombItem;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public int value;

    private float spawnRate;
    private float timeAfterSpawn;
    private Vector3 spawnGer;
    // Start is called before the first frame update
    void Start()
    {
        spawnGer.z = 0;
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        spawnGer.x = Random.Range(-22.3f, 19.2f);
        spawnGer.y = Random.Range(10.2f, -12.6f);

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (spawnGer == playercontrol.instance.transform.position)
        {
            spawnGer.x = Random.Range(-22.3f, 19.2f);
            spawnGer.y = Random.Range(10.2f, -12.6f);
        }
        else
        {
            if (timeAfterSpawn >= spawnRate)
            {
                if(Random.Range(0,101)<=value)
                {
                    timeAfterSpawn = 0;
                    Instantiate(bombItem, spawnGer, transform.rotation);
                    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                    spawnGer.x = Random.Range(-22.3f, 19.2f);
                    spawnGer.y = Random.Range(10.2f, -12.6f);
                }
                else
                {
                timeAfterSpawn = 0;
                Instantiate(grenadepre, spawnGer, transform.rotation);
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                spawnGer.x = Random.Range(-22.3f, 19.2f);
                spawnGer.y = Random.Range(10.2f, -12.6f);
                }
                
            }
        }
    }
}
