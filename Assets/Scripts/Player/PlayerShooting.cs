using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject testPrefab;

    private void Start()
    {
        InvokeRepeating("OnShoot", 0f, 0.5f);
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
