using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditorScript : MonoBehaviour
{
    public GameObject bat;
    BoxCollider2D boxCol;
    public static int count = 0;
    public int cnt;

    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
       // boxCol = bat.GetComponent<BoxCollider2D>();
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Score: " + count.ToString();
        scoreText.text = "Score: "+ count.ToString();
        //Debug.Log(scoreText.text);
        //count++;
        cnt = count;
    }
    
}
