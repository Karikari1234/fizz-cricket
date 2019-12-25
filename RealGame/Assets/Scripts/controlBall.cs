using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBall : MonoBehaviour
{
    public GameObject ball ;
    Vector2 wheretoSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 0.0f;
    public static bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && !gameEnded)
        {
            nextSpawn = Time.time + spawnRate;
            wheretoSpawn = transform.position;
            Instantiate(ball, wheretoSpawn,Quaternion.identity);
        }
    }
}
