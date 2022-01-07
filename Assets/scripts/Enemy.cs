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
    }
    private void Update() {
        Vector2 direction = playerTransform.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * enemySpeed;
    }

    public void TakeDamage() {
        enemyHealth--;
    }
}
