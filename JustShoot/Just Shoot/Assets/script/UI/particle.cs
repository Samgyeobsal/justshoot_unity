using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public ParticleSystem explo;
    //public ParticleSystem nonExplo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(explo)
        {
            if(!explo.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
