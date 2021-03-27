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
    private Vector3 hitNormal;
    private CharacterController charController;

    //Movement

    [SerializeField] private Transform playerMainCam;

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

            // moveInputs = Vector3.ClampMagnitude(moveInputs, 1);

            //Rotation of Player
            if (charVelocity.magnitude > 0.01f && moveInputs != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveInputs);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, playerStats.turnSpeed);
            }

            grounded = charController.isGrounded;

            //Slope Physics
            isSlope = (Vector3.Angle(Vector3.up, hitNormal) <= charController.slopeLimit);



            //Gravity and Falling Velocity
            charVelocity.y += playerStats.gravityScale * Time.deltaTime;


            Vector3 movement = moveInputs * playerStats.moveSpeed;
            movement.y = charVelocity.y;

            if (!isSlope && grounded)
            {
                movement.x += (1f - hitNormal.y) * hitNormal.x * (-playerStats.gravityScale - playerStats.slideFriction);
                movement.z += (1f - hitNormal.y) * hitNormal.z * (-playerStats.gravityScale - playerStats.slideFriction);
            }
            if (grounded && charVelocity.y < 0)
            {
                charVelocity.y = -3f;
            }
            charController.Move(movement * Time.deltaTime);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    public void Jump()
    {
        if (grounded)
        {
            charVelocity.y += Mathf.Sqrt(playerStats.jumpHeight * -3f * playerStats.gravityScale);
        }
    }
}
