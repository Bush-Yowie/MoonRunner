using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 100;
    [SerializeField] int airJumps = 1;
    int currentJumpsLeft = 0;
    [SerializeField] float gravityMultiplier = 20f;
    [SerializeField] float distanceToGround = 1f;
    [SerializeField] float gravity = 9.8f; // gravity is usually 9.8m/s
    // private bool isGrounded;
    private Rigidbody RB;

    // Start is called before the first frame update
    void Start() {
        // gets Rigidbody Component
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // apply Gravity only when not grounded
        if (!IsGrounded()) { RB.AddForce(transform.up * -gravity * gravityMultiplier * Time.deltaTime); }
        Controls();
    }

    // checks for input
    void Controls() {
        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || checkJumps())) {
            RB.AddForce(transform.up * jumpForce);
            currentJumpsLeft--;
        }
    }

    // checks if player is touching the ground
    bool IsGrounded() {
        bool grounded = Physics.Raycast(transform.position, -transform.up, distanceToGround + 0.1f);
        if(grounded) {
            currentJumpsLeft = airJumps; 
        }
        return grounded;
    }

    // checks if jump is available
    bool checkJumps() {
        return (currentJumpsLeft >= 1) ? true : false;
    }
}
