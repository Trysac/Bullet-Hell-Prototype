using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("General Parameters")]
    [SerializeField] float speed = 1f;
    [SerializeField] int pointsPerKill = 1;

    [Header("Initial Values for Properties")]
    [SerializeField] float defence = 0f;
    [SerializeField] float life = 10f;
    [SerializeField] float damage = 1f;

    public bool IsAlive { get; set; }
    public float Damage { get; set; }
    public float Life { get; set; }
    public float Defence { get; set; }
    public Vector3 currentTarget { get; set; }

    public bool IsAttacking { get; set; }

    NavMeshAgent myNavMesh;
    SpawnManager spawnManager;


    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        myNavMesh = GetComponent<NavMeshAgent>();
        myNavMesh.speed = speed;

        //Inial Parameters
        IsAlive = true;
        Damage = damage;
        Life = life;
        Defence = defence;

        IsAttacking = false;

        currentTarget = spawnManager.SetInitialTarget();

    }


    void Update()
    {
        if (IsAlive) 
        {
            myNavMesh.destination = currentTarget;
            if (IsAttacking) 
            {
                Attack();
            }
        }
    }

    public void Attack() 
    {
        print("Attack");
    }

    public void TakeDamage(float damage) 
    {
        Life -= (damage - Defence/2);
        if (Life <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
        Destroy(gameObject);
    }

}
