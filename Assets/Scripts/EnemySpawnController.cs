using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]private GameObject[] enemyPrefab;
    [Range(1,10)][SerializeField]private float spawnRate = 1;


    private void Start() {
        StartCoroutine(SpawnNewEnemy());
    }
    private IEnumerator SpawnNewEnemy(){
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.RandomRange(0.0f,1.0f);
            if(random>GameManager.Instance.difficulty*0.1f){
                Instantiate(enemyPrefab[0]);
            }else{
                Instantiate(enemyPrefab[1]);
            }
        }
    }
}
