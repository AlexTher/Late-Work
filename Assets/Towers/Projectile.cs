using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    private Tower parent;


    void Update()
    {
        MoveToTarget();
    }


    //called by tower
    public void SpawnProjectile(Tower newParent, GameObject newTarget) {
        Projectile newProj = Instantiate(this, newParent.transform.position, Quaternion.identity, newParent.transform);
        newProj.parent = newParent;
        newProj.target = newTarget;
    }
    private void MoveToTarget() {
        Debug.Log("moving?");
        if (target != null && parent != null) {
            Debug.Log(parent);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * parent.projectileSpeed);
        }
    }

    
}
