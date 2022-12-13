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

    private ShopController shopController;
    private Lives live;

    private bool dead = false;

    public static float globalSpeedMod = 1f;
    public AudioSource enemydead;
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
        float distanceAdded = speed * globalSpeedMod * Time.deltaTime;
        distanceTraveled += distanceAdded;
        nodeDistance += distanceAdded;
        transform.position = start.PosOnPath(distanceTraveled, ref nodeDistance, ref parentNode);

        if(distanceTraveled >= 81f && dead == false)
        {
            dead = true;
            live = FindObjectOfType<Lives>();
            live.Lifecounter();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "bullet"){
            Projectile hitProjectile = collider.GetComponent<Projectile>();
            if (hitProjectile != null) {
                hitProjectile.HitEnemy();
            }
            isHit();
        }

        if(collider.gameObject.tag == "endpoint"){
            Destroy(this.gameObject);
            HealthUI.lives=HealthUI.lives-1;
        }

    void isHit(){
		health-=1;
        isDead();
		}
    }

    void isDead(){
        if(health <= 0){
            dead = true;
            enemydead = GameObject.Find("KillEnemyAudio").GetComponent<AudioSource>();
            enemydead.Play();
            points++;
            shopController = FindObjectOfType<ShopController>();
            shopController.enemyKilledAddCurr(1);
            Destroy(this.gameObject); //might need to destroy clone instead
        }
    }
}