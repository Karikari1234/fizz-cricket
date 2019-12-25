using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuGame : MonoBehaviour
{
    int buildIndex;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameStateActive();
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<GameManager>().pauseGame();
        }
    }
}
