using UnityEngine;

// This script handles shovel interaction, allowing destruction when player has red key
public class ShovelScript : MonoBehaviour
{
    // Type of door (unused?)
    public GameBehaviour.DoorType MyDtype;
    // Transform of the door (unused?)
    public Transform DoorT; 
    // Reference to player's collider
    private Collider playerCollider;
    // Whether this is an axe interaction
    public bool IsAxe = false;
    // Axe object to activate
    public GameObject Axe;

    // Tracks whether the player is inside the trigger
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
                if (playerCollider.GetComponentInParent<PlayerMovement>().HasKeyRed == true)
                {
                    Destroy(transform.parent.gameObject);
                    if (IsAxe)
                    {
                        Axe.SetActive(true);
                    }
                }
            }
        }
    }

