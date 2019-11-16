using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_2 : MonoBehaviour
{
    Button player2;
    // Start is called before the first frame update
    void Start()
    {
        player2 = this.GetComponent<Button>();
        player2.onClick.AddListener(click);
    }
    void click()
    {
        SelectManager.instance.whatchar = 1;
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
    void Update()
    {

    }
}