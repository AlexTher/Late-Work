using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemy : MonoBehaviour
{
    public StartNode start;

    PathNode parentNode;
    [HideInInspector] public float nodeDistance = 0f;

    public float distanceTraveled = 0f;
    public float health;
    public float speed;
    int points = 0;

    public void OnHit(float damageDealt)
    {
        health -= damageDealt;
        if (health <= 0f)
        {
            /*
             * play death things
             * possibly have a master player class 
             * that has health, points, and currency all in one
             */
            Destroy(this);
        }
    }

    void Start()
    {
        parentNode = start;
    }

    void Update()
    {
        float distanceAdded = speed * Time.deltaTime;
        distanceTraveled += distanceAdded;
        nodeDistance += distanceAdded;
        transform.position = start.PosOnPath(distanceTraveled, ref nodeDistance, ref parentNode);
    }
}
