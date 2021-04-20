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

    [Header("Targets to Walk to")]
    [SerializeField] Transform[] firstTargetPosition;
    [SerializeField] Transform[] SecondTargetPosition;

    public bool IsAlive { get; set; }
    public float Damage { get; set; }
    public float Life { get; set; }
    public float Defence { get; set; }
    public Vector3 currentTarget { get; set; }

    NavMeshAgent myNavMesh;


    void Start()
    {
        //Inial Parameters
        IsAlive = true;
        Damage = damage;
        Life = life;
        Defence = defence;

        currentTarget = firstTargetPosition[Random.Range(0,firstTargetPosition.Length)].position;

        myNavMesh = GetComponent<NavMeshAgent>();
        myNavMesh.speed = speed;
    }


    void Update()
    {
        if (IsAlive) 
        {
            myNavMesh.destination = currentTarget;
        }
    }

    public void TakeDamage(float damage) 
    {
        Life -= damage;
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
