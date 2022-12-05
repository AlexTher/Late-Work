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

    private float timeBetweenWaves = 2f;
    
    void Update() {
        //removes destroyed enemies
        spawnedEnemies.RemoveAll(GameObject => GameObject == null);
    }
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
        int spawn0 = 20;
        while (spawn0 > 0) {
            
            spawnedEnemies.Add(Instantiate(enemyTypes[0]));
            yield return new WaitForSeconds(.5f);
            spawn0 --;
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(Wave2());
    }


    private IEnumerator Wave2() {
        int spawn1 = 30;
        while (spawn1 > 0) {
            
            spawnedEnemies.Add(Instantiate(enemyTypes[1]));
            yield return new WaitForSeconds(.5f);
            spawn1 --;
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(Wave3());
    }

    

    private IEnumerator Wave3() {
        int spawn0 = 80;
        int spawn1 = 40;
        while (spawn0 > 0) {
            
            spawnedEnemies.Add(Instantiate(enemyTypes[0]));
            yield return new WaitForSeconds(.1f);
            spawnedEnemies.Add(Instantiate(enemyTypes[0]));
            spawnedEnemies.Add(Instantiate(enemyTypes[1]));
            yield return new WaitForSeconds(.5f);
            spawn0 -= 2;
            spawn1 --;
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(Wave4());
    }


    float waveScaling = .75f;
    float curScale = 1f;
    private IEnumerator Wave4() {
        int spawn0 = 50;
        int spawn1 = 50;
        int spawn2 = 50;
        while (spawn0 > 0) {
            
            spawnedEnemies.Add(Instantiate(enemyTypes[0]));
            spawnedEnemies.Add(Instantiate(enemyTypes[1]));
            spawnedEnemies.Add(Instantiate(enemyTypes[2]));
            yield return new WaitForSeconds(.5f * curScale);
            spawn0 --;
            spawn1 --;
            spawn2 --;
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        curScale *= curScale;
        StartCoroutine(Wave4());
    }
}
