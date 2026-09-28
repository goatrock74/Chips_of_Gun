using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [Header("Target_Layer")]
    [SerializeField] private LayerMask bodylayer;
    [SerializeField] private LayerMask headlayer;

    [Header("Ray_Cast")]
    [Min(1)]
    [SerializeField] private float range;

    [Header("References")]
    [SerializeField] private Enemy_Health enemy_health;

    private DG.Tweening.Sequence _seq;


    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            AimBanner();
        }
    }

    private void AimBanner()
    {
        if (Physics.Raycast(transform.position, transform.forward, range, headlayer))
        {
            enemy_health.Damage(150,true);
        }
        else if (Physics.Raycast(transform.position, transform.forward, range, bodylayer))
        {
            enemy_health.Damage(50,false);
        }
        else
        {
            Debug.Log("NO");
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.red);
    }
}
