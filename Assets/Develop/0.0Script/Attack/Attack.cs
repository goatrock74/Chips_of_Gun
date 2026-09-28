using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private Animator ani;
    private bool isshoot;

    private void Awake()
    {
        //asd
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame&&!isshoot)
        {
            StartCoroutine(ShootAnimation());
        }
    }

    private IEnumerator ShootAnimation()
    {
        ani.Play("Shoot");
        yield return null;
        float animationLeght = ani.GetCurrentAnimatorStateInfo(0).length;
        isshoot = true;
        yield return new WaitForSecondsRealtime(animationLeght);
        isshoot = false;
        ani.Play("Idle");
    }
}
