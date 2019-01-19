using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private Rigidbody2D myRigidbody;
  [SerializeField]
  private float movementSpeed;

  void Start() {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");
    HandleMovement(horizontal);
  }

  void HandleMovement(float horizontal) {
    myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
  }

}
