/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;

/*
 * Simple Jump
 * */
public class Player : MonoBehaviour {

    private static Player instance;

    [SerializeField] private LayerMask platformsLayerMask;
    private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private bool waitForStart;
    private bool isDead;

    private void Awake() {
        instance = this;
        playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        waitForStart = true;
        isDead = false;
    }

    private void Update() {
        if (isDead) return;
        if (waitForStart) {
            playerBase.PlayIdleAnim();
            if (Input.GetKeyDown(KeyCode.Space)) {
                waitForStart = false;
            }
        } else {
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
                float jumpVelocity = 100f;
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
            }

            HandleMovement();

            // Set Animations
            if (IsGrounded()) {
                if (rigidbody2d.velocity.x == 0) {
                    playerBase.PlayIdleAnim();
                } else {
                    playerBase.PlayMoveAnim(new Vector2(rigidbody2d.velocity.x, 0f));
                }
            } else {
                playerBase.PlayJumpAnim(rigidbody2d.velocity);
            }
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
    
    private void HandleMovement() {
        float moveSpeed = 40f;
        rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    private void Die() {
        isDead = true;
        rigidbody2d.velocity = Vector3.zero;
    }

    public static void Die_Static() {
        instance.Die();
        GameOverWindow.Show();
    }

}
