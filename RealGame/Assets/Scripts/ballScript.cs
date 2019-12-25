using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ballScript : MonoBehaviour
{
    public float speed; 
    private bool firstFrame = false;
    private Rigidbody2D rb2D;
    public float length;
    static AudioSource audiSrc;
    private bool seen ;
    private Renderer m_renderer;
    public static bool hitByBat = false;
    public static bool hitPitchBeforeBatTouch = false;
    public static bool hitPitchAfterBatTouch = false;
    public static bool scoreDone = false;

    // public static AudioClip Hit;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audiSrc = GetComponent<AudioSource>();
        length = Random.Range(2f, 5f);
        speed = Random.Range(130f,200f) / length;
    }
    // Start is called before the first frame update
    void Start()
    {
        hitByBat = false;
        seen = false;
        hitPitchBeforeBatTouch = false;
        hitPitchAfterBatTouch = false;
        scoreDone = false;

        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (m_renderer.isVisible)
        {
           // Debug.Log("DEKHA JAAY");
            seen = true;
        }
        if (seen)
        {
            if (!m_renderer.isVisible)
            {
                Destroy(gameObject,2f);
                //Debug.Log("Destroyed");
            }

        }
        if (!firstFrame)
        {
            //Debug.Log("YESSSSSS");
            rb2D.AddForce(new Vector2(-length,-1)* speed);
            firstFrame = true;
        }
        //Debug.Log("YESSSSSS");
        // print("YESS");
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audiSrc.Play();
        if (collision.collider.tag == "stumps")
        {
            Debug.Log("Stopp");
            FindObjectOfType<GameManager>().gameOver();
            
        }

        if (collision.collider.tag == "Pitch" && hitByBat)
        {
            hitPitchAfterBatTouch = true;
            //Debug.Log("SIXXXXXXXXXX");
            //TextEditorScript.count += 6;
        }
        if (collision.collider.tag == "Pitch" && !hitByBat)
        {
            hitPitchBeforeBatTouch = true;
            //Debug.Log("SIXXXXXXXXXX");
            //TextEditorScript.count += 6;
        }

        if (collision.collider.tag == "Bat")
        {
            hitByBat = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "SixBoundary" && hitByBat &&!hitPitchAfterBatTouch )
        {
            Debug.Log("SIXXXXXXXXXX");
            TextEditorScript.count += 6;
            FindObjectOfType<GameManager>().changeText("Six");
            
        }
        if (collision.tag == "SixBoundary" && hitByBat && hitPitchAfterBatTouch )
        {
            Debug.Log("Four");
            TextEditorScript.count += 4;
            FindObjectOfType<GameManager>().changeText("Four");

        }
        if(collision.tag == "FourBoundary"&& hitByBat )
        {
            Debug.Log("Four");
            TextEditorScript.count += 4;
            FindObjectOfType<GameManager>().changeText("Four");
        }

        if(collision.tag == "TwoBoundary" && hitByBat)
        {
            Debug.Log("Two");
            TextEditorScript.count += 2;
            FindObjectOfType<GameManager>().changeText("Two");
        }
        if (collision.tag == "OneBoundary" && hitByBat)
        {
            Debug.Log("One");
            TextEditorScript.count += 1;
            FindObjectOfType<GameManager>().changeText("One");
        }
        if (collision.tag == "ThreeBoundary" && hitByBat)
        {
            Debug.Log("Three");
            TextEditorScript.count += 3;
            FindObjectOfType<GameManager>().changeText("Three");
        }

        if (collision.tag == "OutBoundary" && hitByBat && !hitPitchAfterBatTouch)
        {
            Debug.Log("Out");
            FindObjectOfType<GameManager>().gameOver();
        }
        if (collision.tag == "ForwardBoundary" && hitByBat)
        {
            Debug.Log("Four");
            TextEditorScript.count += 4;
            FindObjectOfType<GameManager>().changeText("Four");
        }
        if(collision.tag == "ForwardBoundary" && !hitByBat)
        {
            Debug.Log("Wide");
            TextEditorScript.count += 1;
            FindObjectOfType<GameManager>().changeText("Wide");
        }
        if (collision.tag == "BackBoundary" && hitByBat)
        {
            Debug.Log("Six");
            TextEditorScript.count += 6;
            FindObjectOfType<GameManager>().changeText("Six");
        }
        if (collision.tag == "BackBoundary" && !hitByBat)
        {
            Debug.Log("No Ball");
            TextEditorScript.count += 1;
            FindObjectOfType<GameManager>().changeText("No Ball");
        }
        if (collision.tag == "CaughtBehind" && hitByBat)
        {
            Debug.Log("Caught Behind");
            FindObjectOfType<GameManager>().gameOver();
        }
        //scoreDone = true;
    }
}
