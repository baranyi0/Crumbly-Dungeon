using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPool;

    [SerializeField] GameObject spawnPoint;

    public int spawnChance = 1;

    public void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPool[Random.Range(0,enemyPool.Length)], Vector3.zero, Quaternion.identity);
        enemy.transform.parent = spawnPoint.gameObject.transform;
        enemy.transform.localPosition = Vector3.zero;
    }
}