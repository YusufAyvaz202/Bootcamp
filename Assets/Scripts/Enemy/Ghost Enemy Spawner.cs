using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // D��man prefab'i
    public Transform[] spawnPoints; // Spawn noktalar�n� tutan dizi
    public float spawnInterval = 3f; // Olu�turma aral���

    private float spawnTimer; // Olu�turma zamanlay�c�s�

    private void Start()
    {
        spawnTimer = spawnInterval; // Ba�lang��ta olu�turma zamanlay�c�s�n� ayarla
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime; // Zamanlay�c�y� azalt

        if (spawnTimer <= 0)
        {
            SpawnEnemy(); // Zamanlay�c� s�f�rland���nda d��man olu�tur
            spawnTimer = spawnInterval; // Zamanlay�c�y� yeniden ayarla
        }
    }

    private void SpawnEnemy()
    {
        // Rastgele bir spawn noktas� se�
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Se�ilen spawn noktas�n�n pozisyonunu al
        Vector3 spawnPosition = randomSpawnPoint.position;

        // D��man prefab'ini olu�tur ve konumunu ayarla
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // D��man� belirli bir s�re sonra yok etmek i�in Coroutine ba�lat
        StartCoroutine(DestroyEnemy(enemy));
    }

    private IEnumerator DestroyEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(3f); // Belirli bir s�re beklet

        Destroy(enemy); // D��man� yok et
    }

}
