using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwnController : MonoBehaviour
{
    [SerializeField] GameObject[] enemysPrefab;
    [Range(1, 10)][SerializeField] float spawnRate = 1;

    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy() {
        while (true) {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if(random < GameManager.Instance.difficulty * 0.1f) {
                Instantiate(enemysPrefab[0]);
            } else {
                Instantiate(enemysPrefab[1]);
            }
        }
    }
}
