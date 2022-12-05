using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptBasic : MonoBehaviour
{
    float health = 1.0f;
    float speed = 1.5f;
    bool dead = false;
    int points = 0;
    public GameObject enemy;
    public ShopController shopController;
    int healthPython = 1;


    void Start()
    {
        Debug.Log("ENEMYSCRIPTBASIC");
        //intitalize enemy
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "bullet"){
            isHit(enemy);
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
