using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    private Transform _target;
    
    [Header("Attributes")]
    
    public float range = 15f;
    private float fireRate = 0.3f;
    private float _fireCountdown = 0f;
    
    [Header("Setup Fields")]
    
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {

        GameObject enemyToTarget = null;
        
        foreach (var enemy in WaveSpawner.ActiveEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                enemyToTarget = enemy;
                break;
            }
        }

        if (enemyToTarget != null)
        {
            _target = enemyToTarget.transform;
        }
        else
        {
            _target = null;
        }
        
    }

    void Update()
    {

        if (_target == null)
        {
            return;
        }

        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0)
        {
            Shoot();
            _fireCountdown = 1f * fireRate;
        }

        _fireCountdown -= Time.deltaTime;

    }

    private void Shoot()
    {
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetTarget(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
