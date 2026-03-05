using UnityEngine;

public class BoardScrpt : MonoBehaviour
{
    public GameBehaviour.DoorType MyDtype;
    private Collider playerCollider;
    private bool isPlayer = false;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = true;
            playerCollider = other;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayer = false;
            playerCollider = null;
        }
    }
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
