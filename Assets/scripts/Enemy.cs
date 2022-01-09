using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] int enemyHealth = 1;
    [SerializeField] float enemySpeed = 1;


    private void Start() {
        playerTransform = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int idxSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[idxSpawnPoint].transform.position;
    }
    private void Update() {
        Vector2 direction = playerTransform.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * enemySpeed;
    }

    public void TakeDamage() {
        enemyHealth--;
        if (enemyHealth == 0) {
            Destroy(gameObject);
        }
    }
}
