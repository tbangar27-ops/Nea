using UnityEngine;

// This script handles board interaction, allowing destruction when player has blue key
public class BoardScrpt : MonoBehaviour
{
    // Type of door (unused?)
    public GameBehaviour.DoorType MyDtype;
    // Reference to player's collider
    private Collider playerCollider;
    // Whether the player is in range
    private bool isPlayer = false;

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
    // Check for interaction input
    public void Update() {
if (Input.GetKeyDown(KeyCode.E) && isPlayer)
            {
                if (playerCollider.GetComponentInParent<PlayerMovement>().HasKeyBlue == true)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
