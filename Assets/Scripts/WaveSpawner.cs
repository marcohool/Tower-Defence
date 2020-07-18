using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountText;
    public static List<GameObject> activeEnemies = new List<GameObject>();
    
    private int waveNumber;
    private float countdown = 2f;

    private void Update()
    {
        if (!activeEnemies.Any())
        {
            StartCoroutine(SpawnWave());
        }
    }
    
    private IEnumerator SpawnWave ()
    {
        activeEnemies.Clear();
        waveNumber++;
        waveCountText.text = waveNumber.ToString();
        for (var i = 0; i < waveNumber*2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

    }
    
    private void SpawnEnemy ()
    {
        activeEnemies.Add(Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject);
    }
    
}
