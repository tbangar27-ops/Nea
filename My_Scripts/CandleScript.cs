using UnityEngine;

// This script handles candle pickup, activating the player's candle
public class CandleScript : MonoBehaviour
{
    // Whether the player is in range
    bool isPlayer = false;
    // Reference to player's collider
    private Collider playerCollider;
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
        }}
    // Check for pickup input
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayer == true)
        {
            Transform parentTransform = playerCollider.transform.parent;
            parentTransform.Find("PlayerCandle").gameObject.SetActive(true);
            Destroy(transform.parent.gameObject);
        }
    }
    }