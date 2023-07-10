using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþman prefab'i
    public Transform[] spawnPoints; // Spawn noktalarýný tutan dizi
    public float spawnInterval = 3f; // Oluþturma aralýðý

    private float spawnTimer; // Oluþturma zamanlayýcýsý

    private void Start()
    {
        spawnTimer = spawnInterval; // Baþlangýçta oluþturma zamanlayýcýsýný ayarla
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime; // Zamanlayýcýyý azalt

        if (spawnTimer <= 0)
        {
            SpawnEnemy(); // Zamanlayýcý sýfýrlandýðýnda düþman oluþtur
            spawnTimer = spawnInterval; // Zamanlayýcýyý yeniden ayarla
        }
    }

    private void SpawnEnemy()
    {
        // Rastgele bir spawn noktasý seç
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Seçilen spawn noktasýnýn pozisyonunu al
        Vector3 spawnPosition = randomSpawnPoint.position;

        // Düþman prefab'ini oluþtur ve konumunu ayarla
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Düþmaný belirli bir süre sonra yok etmek için Coroutine baþlat
        StartCoroutine(DestroyEnemy(enemy));
    }

    private IEnumerator DestroyEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(3f); // Belirli bir süre beklet

        Destroy(enemy); // Düþmaný yok et
    }

}
