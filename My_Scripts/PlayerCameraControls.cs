using UnityEngine;

public class PlayerCameraControls : MonoBehaviour
{

    float Xrotation;
    float Yrotation;
    public Transform BodyRotate;
    public float Xsens;
    public float Ysens;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Ysens;

        Yrotation += mouseX;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -80f, 80f);


        transform.rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        BodyRotate.rotation = Quaternion.Euler(0 , Yrotation, 0);

    }
}
