using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private float bombRadius;
    [SerializeField] private GameObject explosionEffect;

    void OnEnable()
    {
        GetComponent<BombSystem>().Explosion += BombExplode;
    }
    void OnDisable()
    {
        GetComponent<BombSystem>().Explosion -= BombExplode;
    }
    public void BombExplode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        StartCoroutine(GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>().Shake(1f, 10.0f));

        Collider[] collision = Physics.OverlapSphere(transform.position, bombRadius);
        
        foreach(Collider nearbyObject in collision)
        {
            Debug.Log("PlayerHitted");
        }

        Destroy(gameObject);


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
