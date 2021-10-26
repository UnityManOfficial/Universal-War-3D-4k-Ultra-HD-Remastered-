using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebomb : MonoBehaviour
{
    [Header("Bomb")]

    [SerializeField] float BombsTimer = 1f;
    [SerializeField] [Range(0, 1)] float ExplosionVolume = 0.75f;
    [SerializeField] AudioClip ExplosionSFX;
    [SerializeField] GameObject ExplosionVFX;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deployed());
    }

    IEnumerator Deployed()
    {
        yield return new WaitForSeconds(BombsTimer);
        Destroy(gameObject);
        GameObject Explode = Instantiate(ExplosionVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position, ExplosionVolume);
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        DeployedAS();
    }

    private void DeployedAS()
    {
        Destroy(gameObject);
        GameObject Explode = Instantiate(ExplosionVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(ExplosionSFX, Camera.main.transform.position, ExplosionVolume);
    }
}
