using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject testPrefab;

    private void Start()
    {
        Attack();
    }

    void Attack()
    {
        StartCoroutine("OnShoot");
    }

    IEnumerator OnShoot()
    {
        while (true)
        {
            CreateProjectile();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
