using UnityEngine;

// 刷怪器：按时间/波次生成敌人
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 8f;

    private float lastSpawn;

    void Update()
    {
        if (Time.time - lastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            lastSpawn = Time.time;
            // 随时间加快刷怪
            spawnInterval = Mathf.Max(0.3f, spawnInterval * 0.995f);
        }
    }

    void SpawnEnemy()
    {
        Vector2 center = transform.position;
        float ang = Random.Range(0f, Mathf.PI * 2f);
        Vector2 pos = center + new Vector2(Mathf.Cos(ang), Mathf.Sin(ang)) * spawnRadius;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
