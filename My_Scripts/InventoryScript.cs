using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public GameObject Key1Sprite;
    public GameObject Key2Sprite;
    public GameObject Key3Sprite;
    public GameObject Key4sprite;
    public GameObject Key5Sprite;
    public GameObject Key6Sprite;
    public PlayerMovement PlayerMovement;
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
}}
