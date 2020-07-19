
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject despawnEffect;
    
    private float speed = 40f;
    private Transform _target;
    private int _currentPosition = 0;
    private void Start()
     {
         _target = Waypoints.Points[0];
     }

    private void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if (_currentPosition == Waypoints.Points.Length - 1)
        {
            
            WaveSpawner.ActiveEnemies.Remove(gameObject);
            GameObject effect = (GameObject) Instantiate(despawnEffect, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
            
            return;
        }

        _currentPosition++;
        _target = Waypoints.Points[_currentPosition];
    }
}
