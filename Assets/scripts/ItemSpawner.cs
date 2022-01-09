using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int checkPointDelay = 10;
    [SerializeField] int powerUpDelay = 12;
    [SerializeField] float circleRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckPointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnCheckPointRoutine() {
        while (true) {
            yield return new WaitForSeconds(checkPointDelay);
            Vector2 randomPosition = Random.insideUnitCircle * circleRadius;
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUpRoutine() {
        while (true) {
            yield return new WaitForSeconds(powerUpDelay);
            Vector2 randomPosition = Random.insideUnitCircle * circleRadius;
            int idx = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[idx], randomPosition, Quaternion.identity);
        }
    }
}
