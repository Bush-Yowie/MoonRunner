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
    // Start is called before the first frame update
    void Start()
    {
        OverworldPlayer = GameObject.FindWithTag("Overworld");
        UnderworldPlayer = GameObject.FindWithTag("Underworld");

        UnderworldPlayer.SetActive(false);

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
            isCounting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isCounting) {
            countTimer = swapTime;
            isCounting = false;
            Debug.Log("RELEASED");
        }

        if(countTimer <= 0)
        {
            Debug.Log("SWAP PLAYERS");
            SwapPlayers(); // function to sawp active player
            countTimer = swapTime;
        }
    }

    void SwapPlayers() {
        OverworldPlayer.SetActive(!OverworldPlayer.activeSelf);
        UnderworldPlayer.SetActive(!OverworldPlayer.activeSelf);
    }
}
