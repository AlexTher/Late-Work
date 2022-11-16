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
    public MasterEnemy target; //current target

    private List<MasterEnemy> targets; //all targets in range

    private bool isFiring;
    void Start()
    {
        isFiring = false;
    }
    void Update()
    {
        
    }

    //add willdie to enemy. tower won't target that enemy anymore

    public void OnTriggerEnter2D(Collider2D enemy) {
        print(enemy.tag);
        if (enemy.tag == "Enemy") {
            target = enemy.GetComponent<MasterEnemy>();
        }
    }

    public void OnTriggerStay2D(Collider2D enemy) {
        if (target != null && !isFiring) {
            StartCoroutine(Shoot());
        }
    }

    //private bool ValidTarget(DummyEnemy enemy) {}
    private IEnumerator Shoot() {
        //Projectile projectile = projectile.SpawnProjectile(this);
        isFiring = true;
        projectile.SpawnProjectile(this, target.gameObject);
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
