using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] [Range(0, 1)] float ExplosionVolume = 0.75f;
    [SerializeField] AudioClip ExplosionSFX;
    [SerializeField] GameObject ExplosionVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject Explode = Instantiate(ExplosionVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position, ExplosionVolume);
    }
}
