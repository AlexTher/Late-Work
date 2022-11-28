using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    public StartNode start;

    PathNode parentNode;

    public float distanceTraveled = 0f;
    float health = 1.0f;
    float speed = 1.5f;
    bool dead = false;
    int points = 0;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //distanceTraveled += speed * Time.deltaTime;
        //transform.position = start.PosOnPath(distanceTraveled);
    }
    
}
