using UnityEngine;

// This script handles the win condition by loading the win scene when the player triggers it
public class WinScript : MonoBehaviour
{
    // Called when another collider enters this trigger collider
    public void OnTriggerEnter(Collider other) {
        // Load the win scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }
}
