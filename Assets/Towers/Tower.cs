using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string towerName;
    public long cost;
    public float range;
    public float damage;
    public float projectileSpeed;
    public float fireRate;

    public Projectile projectile;
    public DummyEnemy target; //current target

    private List<DummyEnemy> targets; //all targets in range

    private bool isFiring;
    void Start()
    {
        isFiring = false;
    }
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.tag == "Enemy") {
            Debug.Log("aaa");
            target = enemy.GetComponent<DummyEnemy>();
        }
    }

    public void OnTriggerStay2D(Collider2D enemy) {
        if (target != null && !isFiring) {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot() {
        //Projectile projectile = projectile.SpawnProjectile(this);
        isFiring = true;
        projectile.SpawnProjectile(this, target.gameObject);
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
