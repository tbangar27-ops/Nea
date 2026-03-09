
using UnityEngine;

public class BoardScrpt : MonoBehaviour
{
    public GameBehaviour.DoorType MyDtype;
    private Collider playerCollider;
    private bool isPlayer = false;
    /* Records object entering hitbox */
    public void OnTriggerEnter(Collider other) {
     /* Checks if object in hitbox is the player */
        if (other.CompareTag("Player")) {
            isPlayer = true;
            playerCollider = other;
        }
    }
     /* Sets record to null when object leaves */
    public void OnTriggerExit(Collider other) {
     /* Checks if object in hitbox is the player */
        if (other.CompareTag("Player")) {
            isPlayer = false;
            playerCollider = null;
        }
    }
     /* Checks if player has the blue key when E is pressed, if they do destroys its parent object */
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

