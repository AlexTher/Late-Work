using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<GameObject> enemyTypes; //fill this list in inspector with enemy types
    public List<GameObject> spawnedEnemies; //destroyed enemies are removed every frame

    public StartNode startNode; //set this in inspector
    void Start()
    {
        if (enemyTypes == null) {
            enemyTypes = new List<GameObject>();
        }
        foreach (GameObject enemy in enemyTypes) {
            MasterEnemy enemyScript = enemy.GetComponent<MasterEnemy>();
            if (enemyScript != null) {
                enemyScript.start = startNode;
            }
            else Debug.Log("couldn't get enemy script");
        }
        StartCoroutine(Wave1());
    }

    private IEnumerator Wave1() {
        int EnemiesToSpawn = 20;
        while (EnemiesToSpawn > 0) {
            
            spawnedEnemies.Add(Instantiate(enemyTypes[0]));
            yield return new WaitForSeconds(.5f);
        }
    }
}
