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
    public static readonly List<GameObject> ActiveEnemies = new List<GameObject>();
    public GameObject spawnEffect;
    
    private int _waveNumber;

    private void Update()
    {
        if (!ActiveEnemies.Any())
        {
            StartCoroutine(SpawnWave());
        }
    }
    
    private IEnumerator SpawnWave ()
    {
        ActiveEnemies.Clear();
        _waveNumber++;
        waveCountText.text = _waveNumber.ToString();
        for (var i = 0; i < _waveNumber*2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

    }
    
    private void SpawnEnemy ()
    {
        GameObject effect = (GameObject) Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation);
        Destroy(effect, 2f);
        ActiveEnemies.Add(Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject);
    }
    
}
