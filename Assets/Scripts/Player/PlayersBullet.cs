using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBullet : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    private void FixedUpdate()
    {
        transform.position += transform.up * 5f * Time.fixedDeltaTime;
    }
}
