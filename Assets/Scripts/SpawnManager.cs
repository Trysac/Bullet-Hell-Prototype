using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("General Parameters")]
    [SerializeField] float spawnRate = .7f;
    [SerializeField] Transform[] spawnPointsPositions;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject[] basicEnemies;
    [SerializeField] GameObject[] mediumEnemies;
    [SerializeField] GameObject[] touhgEnemies;

    [Header("Targets to Walk to")]
    [SerializeField] Transform[] firstTargetPosition;
    [SerializeField] Transform[] secondTargetPosition;
    [SerializeField] Transform finalTargetPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (FindObjectOfType<PlayerController>().IsAlive is false) 
        {
            StopCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies() 
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnEnemy() 
    {
        Instantiate(basicEnemies[Random.Range(0,basicEnemies.Length)], spawnPointsPositions[Random.Range(0, spawnPointsPositions.Length)].position,Quaternion.identity);
    }

    public Vector3 SetInitialTarget() 
    { 
        return firstTargetPosition[Random.Range(0, firstTargetPosition.Length)].position;
    }
    public Vector3 SetNexTargetPos(string tag)
    {
        Vector3 target = new Vector3(0,0,0);
        if (tag.Equals("Target_1"))
        {
            target = secondTargetPosition[Random.Range(0, secondTargetPosition.Length)].position;
        }
        else if (tag.Equals("Target_2") || tag.Equals("Target_Final"))
        {
            target = finalTargetPosition.position;
        }

        return target;
    }
}
