using UnityEngine;

// 玩家控制：移动、射击、拾取效果的管理
// 要点：把此脚本挂到 Player GameObject，Player 需要 Rigidbody2D、Animator（可选）以及子物体用作发射点
public class PlayerController : MonoBehaviour
{
    [Header("移动")]
    public float moveSpeed = 3.5f;

    [Header("射击")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f; // 初始射速（秒）

    private float lastFireTime;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    // 可被拾取、叠加的属性
    [Header("拾取属性（可叠加）")]
    public int projectileCount = 1; // 子弹数量（分散）
    public float projectileSpread = 10f; // 散射角度
    public float projectileSpeed = 6f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 输入
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // 射击（空格）
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            TryFire();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    void TryFire()
    {
        if (projectilePrefab == null || firePoint == null) return;
        if (Time.time - lastFireTime < fireRate) return;
        lastFireTime = Time.time;

        // 发射多发子弹（分散）
        int count = Mathf.Max(1, projectileCount);
        float half = (count - 1) * 0.5f;
        for (int i = 0; i < count; i++)
        {
            float angle = (i - half) * projectileSpread;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject p = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * rot);
            Rigidbody2D prb = p.GetComponent<Rigidbody2D>();
            if (prb)
            {
                prb.velocity = (firePoint.up * projectileSpeed);
            }
        }
    }

    // 当与道具碰撞时（ItemPickup 会负责触发）
    public void ApplyPickup(string id, float value)
    {
        // 简单示例：根据 id 增强属性
        switch (id)
        {
            case "fire_rate":
                fireRate = Mathf.Max(0.05f, fireRate - value);
                break;
            case "projectile_count":
                projectileCount += (int)value;
                break;
            case "projectile_speed":
                projectileSpeed += value;
                break;
            case "move_speed":
                moveSpeed += value;
                break;
            case "spread_reduce":
                projectileSpread = Mathf.Max(0, projectileSpread - value);
                break;
            default:
                Debug.Log("Unknown pickup: " + id);
                break;
        }

        // 通知 GameManager（用于统计/保存）
        GameManager.Instance?.OnPlayerPickup(id, value);
    }
}
