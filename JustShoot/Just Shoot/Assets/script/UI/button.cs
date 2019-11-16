using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    Button but;
    void Start()
    {
        but = this.transform.GetComponent<Button>();
        but.onClick.AddListener(fclick);
    }
    void fclick()
    {
        SceneManager.LoadScene("SelectCharScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
