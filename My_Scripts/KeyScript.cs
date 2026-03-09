using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script handles key pickup functionality
public class KeyScript : MonoBehaviour
{
    // Whether the player is in range
    bool isPlayer = false;
    // Reference to the player's collider
    private Collider playerCollider;
    // Type of key this script represents
    public GameBehaviour.KeyType KType;

    // Called when a collider enters the trigger
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = true;
            playerCollider = other;
        }
    }

    // Called when a collider exits the trigger
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = false;
            playerCollider = null;
        }
    }

    // Check for pickup input
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer) {
            PickUpKey();
        }
    }

    // Pick up the key and update player inventory
    private void PickUpKey() {
        PlayerMovement Pmovement = playerCollider.GetComponentInParent<PlayerMovement>();
        if(KType == GameBehaviour.KeyType.RedKey)
        {
            Pmovement.HasKeyRed = true;
        }
        else if(KType == GameBehaviour.KeyType.BlueKey)
        {
            Pmovement.HasKeyBlue = true;
        }
        else if(KType == GameBehaviour.KeyType.YellowKey)
        {
            Pmovement.HasKeyYellow = true;
        }
        Destroy(transform.parent.gameObject);
    }

}
