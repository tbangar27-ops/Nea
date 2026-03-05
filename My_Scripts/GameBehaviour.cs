using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public KeyType Ktype;
    public enum KeyType
    {
        RedKey,
        BlueKey,
        YellowKey,
    }
    public enum DoorType
    {
        Red,
        Blue,
        Yellow,
    }

}
