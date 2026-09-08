using UnityEngine;

// 道具拾取：被玩家触碰触发效果，然后自毁
public class ItemPickup : MonoBehaviour
{
    public string pickupId = "projectile_count";
    public float value = 1f;
    public float lifetime = 15f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplyPickup(pickupId, value);
            }
            Destroy(gameObject);
        }
    }
}
