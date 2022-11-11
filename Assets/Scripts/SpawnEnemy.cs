using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    bool isspawn = true;
    public DummyEnemy enem;
    /*
    public void OnTriggerEnter2D(Collider2D enemy) {
        if (enemy.tag == "Enemy") {
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
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD:Assets/SpawnEnemy.cs
    /*
    IEnumerator spawn(){
        if(isspawn){

        }
    }*/
=======
    //IEnumerator spawn(){
    //    if(isspawn){

    //    }
    //}
>>>>>>> main:Assets/Scripts/SpawnEnemy.cs
}
