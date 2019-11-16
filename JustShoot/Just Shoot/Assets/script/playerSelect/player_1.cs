using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class    player_1 : MonoBehaviour
{
    Button player1;
    // Start is called before the first frame update
    void Start()
    {
        player1 = this.GetComponent<Button>();
        player1.onClick.AddListener(click);
       }
    
    void click()
    {
        SelectManager.instance.whatchar = 0;
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
