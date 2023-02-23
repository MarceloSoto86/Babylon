using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private float spawnRange = 300;
    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber = 1;


    private void Start()
    {
        SpawnEnemyWave(waveNumber); //ABSTRACTION
            
    }

    private void Update()
    {
        EnemyCount(); //ABSTRACTION
    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomSpawnPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            int randomEnemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemyIndex], GenerateSpawnPosition(), enemies[randomEnemyIndex].gameObject.transform.rotation);
        }
    }

    void EnemyCount()
    { 
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {

            waveNumber++;
            SpawnEnemyWave(waveNumber);

            /*// CÓDIGO PARA SPAWNEAR POWERUPS
            int powerupIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[powerupIndex], GenerateSpawnPosition(), powerupPrefabs[powerupIndex].gameObject.transform.rotation);*/
        }
    }
}
