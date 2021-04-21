using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float life = 100f;
    [SerializeField] GameObject bullet;

    [Header("Rotation Values")]
    // transform.rotation.y returns values between -1 an 1.
    [SerializeField] float minRotation = -0.5f;
    [SerializeField] float maxRotation = 0.5f;

    public bool IsAlive { get; set; }
    public float Life { get; set; }

    private void Awake()
    {
        Life = life;
    }
    private void Start()
    {
        IsAlive = true;
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement = transform.rotation.y < minRotation ? (movement > 0 ? movement : 0) : (transform.rotation.y > maxRotation ? (movement < 0 ? movement : 0) : movement);

        transform.Rotate(new Vector3(transform.rotation.x, movement, transform.rotation.z));
    }
}
