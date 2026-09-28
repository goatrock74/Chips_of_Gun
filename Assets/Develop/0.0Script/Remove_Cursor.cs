using UnityEngine;
using UnityEngine.InputSystem;

public class Remove_Cursor : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
    }
}
