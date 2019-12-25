using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batScript : MonoBehaviour
{
    Joystick joyStick;
    Vector2 startPosition, endPosition;
    Rigidbody2D rigidbody;
    //bool isDragging = false;
    HingeJoint2D hinge2d;
    //bool tap = false;
    public int cnt;
    Vector3 initialPos;
    public float batSpeed;
    bool firstFrameGone = false;
    // Start is called before the first frame update
    void Start()
    {
        //hinge2d = gameObject.GetComponent<HingeJoint2D>();
        joyStick = FindObjectOfType<Joystick>();
        rigidbody = GetComponent<Rigidbody2D>();
        initialPos = gameObject.transform.position;
        gameObject.transform.eulerAngles = new Vector3(
     gameObject.transform.eulerAngles.x,
     gameObject.transform.eulerAngles.y ,
     gameObject.transform.eulerAngles.z -15f
 );
    }

    // Update is called once per frame
    void Update()
    {
        if (!controlBall.gameEnded)
        {
           // Vector3 rotation;


            if ((joyStick.Horizontal > 0.1f || joyStick.Horizontal < 0.1f || joyStick.Vertical > 0.1f ||joyStick.Vertical <0.1f) && (joyStick.Horizontal != 0.0f ||joyStick.Vertical != 0.0f) )
            {
                Debug.Log("Joystick");
                gameObject.transform.Translate(joyStick.Horizontal * Time.deltaTime*batSpeed,joyStick.Vertical *Time.deltaTime*batSpeed,0);
                //rotation = gameObject.transform.position - initialPos;
                // gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation.x*30f);
                //gameObject.transform.position += Vector3.forward;
                firstFrameGone = true;
            }
            Vector3 rotation;
            rotation = gameObject.transform.position - initialPos;
            if(firstFrameGone == true) {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation.x * 30f);
            }
            
            float xPosition = gameObject.transform.position.x;
            float yPosition = gameObject.transform.position.y;

            xPosition = Mathf.Clamp(gameObject.transform.position.x, -5f, -1.5f);
            yPosition = Mathf.Clamp(gameObject.transform.position.y,-3.05f , -1.5f);

            Vector2 clampedVector = new Vector2(xPosition, yPosition);

            gameObject.transform.position = clampedVector;

           
            /*if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                startPosition = Input.mousePosition;
                //Debug.Log();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Reset();
                isDragging = false;
            }
            if (isDragging)
            {
               // transform.Rotate(new Vector3(0, 0, 1), 10f);
            }

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Reset();
                tap = false;
            }

            if (tap)
            {
               // transform.Rotate(new Vector3(0, 0, 1), 5f);
            }*/

        }
    }

    private void Reset()
    {
        //Debug.Log("reset");
       // transform.;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TextEditorScript.count++;
        //cnt = TextEditorScript.count;
}
}
