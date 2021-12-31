using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] Vector3 moveDirection;
  [SerializeField] float moveSpeed = 2;

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
  }
}
