using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour {

    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    
    public Wizard wizard;
    Rigidbody rb;

    public void Initialize(Vector3 velocity)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }

    public void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherCharecter = collision.gameObject.GetComponent<Character>();
        if (otherCharecter != null)
        {
            otherCharecter.TakeDamage(wizard.attackDamage);
        }
        Destroy(gameObject);
    }
    
}
