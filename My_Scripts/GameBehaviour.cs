using UnityEngine;

// This class defines enums for key and door types used throughout the game
public class GameBehaviour : MonoBehaviour
{
    // Current key type (not used in this script)
    public KeyType Ktype;
    // Enum for different key types
    public enum KeyType
    {
        RedKey,
        BlueKey,
        YellowKey,
    }
    // Enum for different door types
    public enum DoorType
    {
        Red,
        Blue,
        Yellow,
    }

}
