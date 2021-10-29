using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // public PlayerCharacter_SO playerStats;

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
    private PlayerStatus pStatus;
    //Movement

    [SerializeField] private Transform playerMainCam;
    [SerializeField] private Transform playerResetPoint;

    private void Awake()
    {
        pStatus = GetComponent<PlayerStatus>();
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        //Setting up speed from playerChar_SO
        moveSpeed = pStatus.playerStats.currentSpeed;
        distanceToGround = charController.bounds.extents.y;
    }



    public void Move(Vector2 playerInputs)
    {
        Ray downray = new Ray(transform.position + transform.forward * pStatus.playerStats.castOffset, Vector3.down);

        //Raycast for shadow prefab in FUTURE
        // if (Physics.Raycast(downray, out RaycastHit hit, Mathf.Infinity))
        // {

        // }

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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, pStatus.playerStats.turnSpeed);
        }

        grounded = charController.isGrounded;

        //Slope Physics
        isSlope = (Vector3.Angle(hitNormal, Vector3.up) <= charController.slopeLimit);

        //Gravity and Falling Velocity
        Vector3 movement = moveInputs * moveSpeed;
        charVelocity.y += pStatus.playerStats.gravityScale * Time.deltaTime;
        movement.y = charVelocity.y;

        //Slide from slope
        if (!isSlope && grounded)
        {
            movement.x += ((1f - hitNormal.y) * hitNormal.x) * pStatus.playerStats.slideFriction;
            movement.z += ((1f - hitNormal.y) * hitNormal.z) * pStatus.playerStats.slideFriction;
            moveSpeed = moveSpeed / 2;
        }
        else
        {
            moveSpeed = pStatus.playerStats.currentSpeed;
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

        //SP charging condition
        if (grounded)
        {
            pStatus.SpStop = false;
            pStatus.IsJumping = false;
        }
        else
        {
            pStatus.IsJumping = true;
            pStatus.SpStop = true;
        }


        //Check if player is moving
        if (moveInputs.magnitude != 0)
        {
            pStatus.IsMoving = true;
        }
        else
        {
            pStatus.IsMoving = false;
        }

        //character Moving
        charController.Move(movement * Time.deltaTime);
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
        //sp charging stops when jumping

        if (isSlope)
        {
            if (grounded || coyoteJump && jumpCount <= 0)
            {
                jumpCount++;
                charVelocity.y += Mathf.Sqrt(pStatus.playerStats.jumpHeight * -3f * pStatus.playerStats.gravityScale);

            }
        }
    }

    public void Sprint(bool _isSprinting)
    {
        pStatus.IsSprinting = _isSprinting;

        if (pStatus.CurrentSP >= 0 && pStatus.spRate >= 0f && _isSprinting == true)
        {
            pStatus.playerStats.currentSpeed = pStatus.playerStats.sprintSpeed;
        }
        else if (_isSprinting == false)
        {

            pStatus.playerStats.currentSpeed = pStatus.playerStats.normalSpeed;

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

    public void FreeMoveMode(Vector2 MovementInputs, float yMovementInputs)
    {
        moveInputs = new Vector3(MovementInputs.x, yMovementInputs, MovementInputs.y);

        transform.position += moveInputs * (moveSpeed + 3f) * Time.deltaTime;

        Debug.Log("freeMove");
    }

    public void ResetPosition()
    {
        gameObject.transform.position = playerResetPoint.position;
        Debug.Log("Reset");
    }

}
