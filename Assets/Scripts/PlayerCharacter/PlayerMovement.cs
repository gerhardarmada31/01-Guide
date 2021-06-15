using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public PlayerCharacter_SO playerStats;

    private Vector3 moveInputs;
    private Vector3 charVelocity;
    private bool grounded;
    private bool isSlope;
    private float moveSpeed;
    private float distanceToGround;
    private Vector3 hitNormal;

    private bool coyoteJump;
    private float coyoteTimer = 0.2f;
    private int jumpCount = 0;

    private CharacterController charController;

    //Movement

    [SerializeField] private Transform playerMainCam;

    private void Start()
    {
        moveSpeed = playerStats.moveSpeed;
        distanceToGround = charController.bounds.extents.y;
    }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 playerInputs)
    {

        Ray downray = new Ray(transform.position + transform.forward * playerStats.castOffset, Vector3.down);

        if (Physics.Raycast(downray, out RaycastHit hit, Mathf.Infinity))
        {

            //Camera Relativity
            Vector3 camF = playerMainCam.forward;
            Vector3 camR = playerMainCam.right;
            camF.y = 0;
            camR.y = 0;
            camF.Normalize();
            camR.Normalize();


            moveInputs = new Vector3(playerInputs.x, 0, playerInputs.y);
            moveInputs = moveInputs.z * camF + moveInputs.x * camR;
            moveInputs = Vector3.ClampMagnitude(moveInputs, 1);

            //Rotation of Player
            if (charVelocity.magnitude > 0.01f && moveInputs != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveInputs);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, playerStats.turnSpeed);
            }

            grounded = charController.isGrounded;
            // if (Physics.Raycast(charController.bounds.center, Vector3.down * (distanceToGround + 1f)))
            // {
            //     grounded = true;
            // }
            // else
            // {
            //     grounded = false;
            // }
            // grounded = Physics.SphereCast(transform.position, charController.radius / 2, -transform.up, out RaycastHit hit1, distanceToGround + 0.5f);

            //Slope Physics
            isSlope = (Vector3.Angle(hitNormal, Vector3.up) <= charController.slopeLimit);

            //Gravity and Falling Velocity
            Vector3 movement = moveInputs * moveSpeed;
            charVelocity.y += playerStats.gravityScale * Time.deltaTime;
            movement.y = charVelocity.y;

            bool _wasGrounded = grounded;

            if (!isSlope && grounded)
            {
                movement.x += ((1f - hitNormal.y) * hitNormal.x) * playerStats.slideFriction;
                movement.z += ((1f - hitNormal.y) * hitNormal.z) * playerStats.slideFriction;
                moveSpeed = moveSpeed / 2;
            }
            else
            {
                moveSpeed = playerStats.moveSpeed;
            }

            if (isSlope && grounded && charVelocity.y < 0)
            {
                charVelocity.y = -3f;
                jumpCount = 0;
            }
            else
            {
                StartCoroutine(CoyoteJumpDelay());
            }

            charController.Move(movement * Time.deltaTime);
        }
    }

    IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(coyoteTimer);
        coyoteJump = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    public void Jump()
    {
        if (grounded || coyoteJump && jumpCount <= 0)
        {
            jumpCount++;
            charVelocity.y += Mathf.Sqrt(playerStats.jumpHeight * -3f * playerStats.gravityScale);
        }
    }

    private void OnDrawGizmos()
    {
        if (charController != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(charController.bounds.center, Vector3.down * (charController.bounds.extents.y + 1f));
        }
    }

    //add a parameter to increase based on the boost value
    public void GhostBoost(Transform ghostPosition, float ghostForce)
    {
        charController.enabled = false;
        transform.position = ghostPosition.transform.position;
        charController.enabled = true;
        charVelocity.y = ghostForce;

        //In case of setting a transform position, translate it.
        // transform.Translate()
    }
}
