using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_nonexplo : MonoBehaviour
{
    public ParticleSystem nonExplo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nonExplo)
        {
            if (!nonExplo.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
