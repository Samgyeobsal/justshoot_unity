using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager instance;
    public int whatchar = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    private void Update()
    {

    }
    // Start is called before the first frame update
}
