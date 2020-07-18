
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 40f;
    private Transform target;
    private int currentPosition = 0;
    private void Start()
     {
         target = Waypoints.points[0];
     }

    private void Update()
    {
        var dir = target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if (currentPosition == Waypoints.points.Length - 1)
        {
            
            WaveSpawner.activeEnemies.Remove(gameObject);
            Destroy(gameObject);
            
            return;
        }

        currentPosition++;
        target = Waypoints.points[currentPosition];
    }
}
