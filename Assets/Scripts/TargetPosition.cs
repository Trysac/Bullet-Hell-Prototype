using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    SpawnManager spawnManager;
    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy")) 
        {
            other.gameObject.GetComponent<Enemy>().currentTarget = spawnManager.SetNexTargetPos(tag);
            if (tag.Equals("Target_Final")) 
            {
                other.gameObject.GetComponent<Enemy>().IsAttacking = true;
            }
        }
    }
}
