using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    [SerializeField] float fireDelay = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Fire());
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        {
            StopAllCoroutines();
        }
    }

    public Vector3 GetBarrelPosition() 
    {
        return barrel.position;
    }

    private IEnumerator Fire()
    {
        Instantiate(bullet, barrel.position, Quaternion.identity);
        yield return new WaitForSeconds(fireDelay);
        StartCoroutine(Fire());
    }
}
