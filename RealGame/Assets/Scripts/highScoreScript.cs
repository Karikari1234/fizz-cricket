using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreScript : MonoBehaviour
{
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.DeleteKey("HighScore");
        highScore = GetComponent<Text>();
       highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
       // PlayerPrefs.DeleteKey("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(TextEditorScript.count > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", TextEditorScript.count);
            highScore.text = "High Score: " + TextEditorScript.count.ToString();
            Debug.Log(highScore.text);
        }
    }
}
