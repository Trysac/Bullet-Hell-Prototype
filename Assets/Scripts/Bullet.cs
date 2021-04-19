using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float destoyProjectileDelay = 0.2f;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;
        Destroy(gameObject, destoyProjectileDelay);
    }

    void Update()
    {
        myRigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);

    }
}
