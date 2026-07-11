using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private Animator ani;
    private bool isshoot = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootAnimation();
        }
    }

    private void ShootAnimation()
    {
        isshoot = true;
        ani.Play("Shoot");
        if (isshoot && ani.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            ani.Play("Idle");
        }
    }

}
