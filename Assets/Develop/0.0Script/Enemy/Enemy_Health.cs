using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    private int health = 150;

    private bool islive = true;


    public void Damage(int damage,bool ishead)
    {
        if (islive) return;

        if (health - damage <= 0) return;

        if (ishead)
            Debug.Log("head_shot");

        health -= damage;
    }
}
