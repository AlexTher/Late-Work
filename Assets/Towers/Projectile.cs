using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    private Tower parent;


    void Update()
    {
        MoveToTarget();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
        }
    }


    //called by tower
    public void SpawnProjectile(Tower newParent, GameObject newTarget) {
        Projectile newProj = Instantiate(this, newParent.transform.position, Quaternion.identity, newParent.transform);
        newProj.parent = newParent;
        newProj.target = newTarget;
    }
    private void MoveToTarget() {
        if (parent != null) {
            if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * parent.projectileSpeed);
            }
            else {
                if (parent.target != null) {
                    target = parent.target.gameObject;
                }
                if (target == null) {
                    //maybe only destroy them if outside of tower range. that requires too much thinking though
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
