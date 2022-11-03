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
        distanceTraveled += speed * Time.deltaTime;
        transform.position = start.PosOnPath(distanceTraveled);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "bullet"){
            isHit(enemy);
        }

        if(collider.gameObject.tag == "endpoint"){
            Destroy(this.gameObject);
            HealthUI.lives=HealthUI.lives-5;
        }

    void isHit(GameObject obj){
		health-=1;
		isDead(obj);
		}
    }

    void isDead(GameObject obj){
        if(health <= 0){
            dead = true;
            points++;
            Destroy(obj); //might need to destroy clone instead
        }
    }
}
