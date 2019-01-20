using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private Rigidbody2D myRigidbody;
  [SerializeField]
  private float movementSpeed;
  private bool facingRight;
  private Animator myAnimator;
  private bool attack;

  void Start() {
    facingRight = true;
    myRigidbody = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");
    HandleMovement(horizontal);
    Flip(horizontal);
    HandleAttacks();
    ResetValues();
  }

  private void Update() {
    HandleInput();
  }

  void HandleInput() {
    if (Input.GetKeyDown(KeyCode.LeftShift)) {
      attack = true;
    }
  }

  void HandleMovement(float horizontal) {
    if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
      myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
    }
    myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
  }

  private void Flip(float horizontal) {
    if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
      facingRight = !facingRight;
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
  }

  private void HandleAttacks() {
    if (attack && !myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
      myAnimator.SetTrigger("attack");
      myRigidbody.velocity = Vector2.zero;
    }
  }

  private void ResetValues() {
    attack = false;
  }
}
