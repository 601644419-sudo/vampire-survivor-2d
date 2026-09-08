using UnityEngine;

// 敌人：简单向玩家移动并接触造成伤害
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public int maxHealth = 3;
    private int currentHealth;
    private Transform player;

    void Awake()
    {
        currentHealth = maxHealth;
        var p = GameObject.FindWithTag("Player");
        if (p) player = p.transform;
    }

    void FixedUpdate()
    {
        if (player)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * moveSpeed;
        }
    }

    public void TakeDamage(int v)
    {
        currentHealth -= v;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 可掉落道具（概率）
        float dropChance = 0.25f;
        if (Random.value < dropChance && GameManager.Instance.itemPickupPrefab != null)
        {
            Instantiate(GameManager.Instance.itemPickupPrefab, transform.position, Quaternion.identity);
        }

        GameManager.Instance?.OnEnemyKilled();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // TODO: 对玩家造成伤害（可扩展）
        }
    }
}
