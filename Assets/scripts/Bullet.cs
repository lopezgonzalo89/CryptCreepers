using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;

    private void Start() {
        // No funciona
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
          collision.GetComponent<Enemy>().TakeDamage();
          Destroy(gameObject);
        }
    }
}
