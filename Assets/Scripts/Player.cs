using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private Rigidbody2D myRigidbody;
  [SerializeField]
  private float movementSpeed;
  private bool facingRight;

  void Start() {
    facingRight = true;
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");
    HandleMovement(horizontal);
    Flip(horizontal);
  }

  void HandleMovement(float horizontal) {
    myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
  }

  private void Flip(float horizontal) {
    if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
      facingRight = !facingRight;
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
  }

}
