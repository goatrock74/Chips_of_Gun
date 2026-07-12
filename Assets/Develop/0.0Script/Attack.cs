using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject attack_Light;
    private Animator ani;
    private bool isshoot;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        attack_Light.SetActive(false);
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
        attack_Light.SetActive(true);
        yield return new WaitForSecondsRealtime(animationLeght);
        attack_Light.SetActive(false);
        isshoot = false;
        ani.Play("Idle");
    }
}
