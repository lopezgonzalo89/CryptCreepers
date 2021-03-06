using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] int heroHealth = 5;
  [SerializeField] float moveSpeed = 4;
  [SerializeField] float fireRate = 3;
  [SerializeField] Vector3 moveDirection;
  [SerializeField] Transform aim;
  [SerializeField] Camera camera;
  [SerializeField] Transform bulletPrefab;
  Vector2 facingDirection;
  bool gunLoaded = true;

  // Start is called before the first frame update
  void Start()
  {
    print("Hola Unity");
  }

  // Update is called once per frame
  void Update()
  {
    moveDirection.x = Input.GetAxis("Horizontal");
    moveDirection.y = Input.GetAxis("Vertical");

    transform.position += moveDirection * Time.deltaTime * moveSpeed;

    // Sight movement
    facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    aim.position = (Vector3)facingDirection.normalized + transform.position; 

    if (Input.GetMouseButton(0) && gunLoaded) {
      gunLoaded = false;
      float shootAngle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
      Quaternion shootRotation = Quaternion.AngleAxis(shootAngle, Vector3.forward);
      Instantiate(bulletPrefab, transform.position, shootRotation);
      StartCoroutine(ReloadGun());
    }

    if (heroHealth == 0) {
      // Game Over
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag("Enemy")) {
      heroHealth--;
    }
  }

  IEnumerator ReloadGun() {
    yield return new WaitForSeconds(1/fireRate);
    gunLoaded = true;
  }
}
