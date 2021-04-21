using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 1f;
    [SerializeField] float destoyProjectileDelay = 0.2f;

    public float Damage { get; set; }

    Rigidbody myRigidbody;

    void Start()
    {
        Damage = damage;

        myRigidbody = GetComponent<Rigidbody>();
        transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;

        Destroy(gameObject, destoyProjectileDelay);
    }

    void Update()
    {
        myRigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy")) 
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
