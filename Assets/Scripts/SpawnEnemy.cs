using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("Scene").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (Random.value > 0.82 && spawnManager.spawnChance > 2) || (spawnManager.spawnChance <= 0))
        {
            spawnManager.spawnChance = Random.Range(4, 10);
            spawnManager.SpawnEnemy();
        }
        spawnManager.spawnChance--;
    }
}
