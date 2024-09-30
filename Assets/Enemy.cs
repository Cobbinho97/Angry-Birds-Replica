using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject cloudParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bird>() != null)
        {
            Instantiate(cloudParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < - 0.5)
        {
            Instantiate(cloudParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
