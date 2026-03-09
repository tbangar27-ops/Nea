using UnityEngine;
using UnityEngine.UI;

// This script manages the inventory UI, displaying collected keys
public class InventoryScript : MonoBehaviour
{
    // Sprite for red key
    public GameObject Key1Sprite;
    // Sprite for blue key
    public GameObject Key2Sprite;
    // Sprite for yellow key
    public GameObject Key3Sprite;
    // Unused key sprites
    public GameObject Key4sprite;
    public GameObject Key5Sprite;
    public GameObject Key6Sprite;
    // Reference to player movement script
    public PlayerMovement PlayerMovement;
    // Update inventory display based on player keys
    public void Update()
    {
        if (PlayerMovement.HasKeyRed == true)
        {
            Key1Sprite.SetActive(true);
        }
        if (PlayerMovement.HasKeyBlue == true)
        {
            Key2Sprite.SetActive(true);
        }
        if (PlayerMovement.HasKeyYellow == true)
        {
            Key3Sprite.SetActive(true);
        }
    }
}
