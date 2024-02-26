using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerController : MonoBehaviour
{
    [SerializeField] GameObject OverworldPlayer;
    [SerializeField] GameObject UnderworldPlayer;
    [SerializeField] float swapTime = 0.2f;
    bool isCounting = false;
    [SerializeField] float countTimer = 0;

    bool swap = false;

    public delegate void jump();
    public static event jump OnJump;
    // Start is called before the first frame update
    void Start()
    {
        OverworldPlayer = GameObject.FindWithTag("Overworld");
        UnderworldPlayer = GameObject.FindWithTag("Underworld");

        UnderworldPlayer.GetComponent<Sc_PlayerMovement>().isActive = false;

        countTimer = swapTime;
        // Get overworld and underworld players with tags
        // set underworld to inactive
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            countTimer -= Time.deltaTime;
            Debug.Log("REDUCING TIME");
            if (countTimer <= 0)
            {
                 // function to sawp active player
                countTimer = swapTime;
                swap = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) {
            if(countTimer > 0) {
                if(OnJump != null) { OnJump(); }
            }
            countTimer = swapTime;
            isCounting = true;
            Debug.Log("RELEASED");
        }

        SwapPlayers();
    }

    void SwapPlayers() {
        if(swap && (OverworldPlayer.GetComponent<Sc_PlayerMovement>().IsGrounded() && UnderworldPlayer.GetComponent<Sc_PlayerMovement>().IsGrounded()))
        {
            OverworldPlayer.GetComponent<Sc_PlayerMovement>().isActive = !OverworldPlayer.GetComponent<Sc_PlayerMovement>().isActive;
            
            UnderworldPlayer.GetComponent<Sc_PlayerMovement>().isActive = !UnderworldPlayer.GetComponent<Sc_PlayerMovement>().isActive;
            
            swap = false;
        }

    }
}
