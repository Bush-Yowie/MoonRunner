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
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] GameObject bean;
    public bool isActive = true;
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
        if (!IsGrounded() && isActive) { RB.AddForce(transform.up * -gravity * gravityMultiplier * Time.deltaTime); } else if (!isActive) { RB.velocity = Vector3.zero; }
        //RB.velocity = new Vector3(0, RB.velocity.y, 0) + Vector3.right * playerSpeed;
        if(!isActive) { bean.SetActive(false); } else { bean.SetActive(true); }
    }

    void OnEnable()
    {
        Sc_PlayerController.OnJump += Jumping;
    }

    void OnDisable()
    {
        Sc_PlayerController.OnJump -= Jumping;
    }

    void Jumping()
    {
        if(isActive && (IsGrounded() || CheckJumps()))
        {
            //RB.velocity = Vector3.up * jumpForce;
            RB.AddForce(transform.up * jumpForce);
            currentJumpsLeft--;
        }
    }

    // checks if player is touching the ground
    public bool IsGrounded() {
        bool grounded = Physics.Raycast(transform.position, -transform.up, distanceToGround + 0.1f);
        if(grounded) {
            currentJumpsLeft = airJumps; 
        }
        return grounded;
    }

    // checks if jump is available
    bool CheckJumps() {
        return (currentJumpsLeft >= 1) ? true : false;
    }
}
