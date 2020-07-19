using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform _target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void SetTarget(Transform _target)
    {
        this._target = _target;
    }
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) // If target has hit
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        WaveSpawner.ActiveEnemies.Remove(_target.gameObject);
        Destroy(_target.gameObject);
        Destroy(gameObject);
        
    }
}
