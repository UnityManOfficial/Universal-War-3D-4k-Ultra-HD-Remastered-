using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] bool Invincible = false;
    [SerializeField] float damage = 1;

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (!Invincible)
        {
            Destroy(gameObject);
        }
    }
}
