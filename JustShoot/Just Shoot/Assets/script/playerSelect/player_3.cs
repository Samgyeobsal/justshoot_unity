using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_3 : MonoBehaviour
{
    Button player3;
    // Start is called before the first frame update
    void Start()
    {
        player3 = this.GetComponent<Button>();
        player3.onClick.AddListener(click);
    }
    void click()
    {
        SelectManager.instance.whatchar = 2;
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
}
