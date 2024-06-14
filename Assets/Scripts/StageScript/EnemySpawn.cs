using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Signal enemySignal;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] enemyPos;
    [SerializeField] bool isSpawnWithTrigger;
    public float spawnDelayTime;
    [HideInInspector] public bool isSpawned;
    public int enemyAmount;
    private bool isSpawn;

    private void Update()
    {
        if (isSpawn && !isSpawned)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject newEnemy = Instantiate(enemy, enemyPos[i].position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().deathSignal = enemySignal;
                if (i < enemyAmount)
                {
                    isSpawn = false;
                    isSpawned = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.GetComponent<StageManagement>().isEntered)
        {
            if (other.CompareTag("Player"))
            {
                if (isSpawnWithTrigger)
                {
                    StartCoroutine(EnemySpawnCo());
                }
            }
        }
    }

    public void ManualSpawnEnemy()
    {
        if (gameObject.GetComponent<StageManagement>().isAnyPlayer)
        {
            StartCoroutine(EnemySpawnCo());
        }
    }

    private IEnumerator EnemySpawnCo()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        isSpawn = true;
    }
}
