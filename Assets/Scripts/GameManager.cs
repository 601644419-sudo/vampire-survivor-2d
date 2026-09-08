using UnityEngine;

// 全局游戏管理
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("预制体引用（在场景中拖拽）")]
    public GameObject itemPickupPrefab;

    private float startTime;
    private int enemiesKilled = 0;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        startTime = Time.time;
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;
    }

    public void OnPlayerPickup(string id, float value)
    {
        // 可在此统计或触发 UI
        Debug.Log($"Player picked up {id} (+{value})");
    }

    public float GetSurviveTime()
    {
        return Time.time - startTime;
    }

    // 简单存档：解锁角色、最高生存时间
    public void SaveUnlock(string characterId)
    {
        string key = $"unlock_{characterId}";
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }

    public bool IsUnlocked(string characterId)
    {
        string key = $"unlock_{characterId}";
        return PlayerPrefs.GetInt(key, 0) == 1;
    }

    public void SaveBestTime(float seconds)
    {
        float best = PlayerPrefs.GetFloat("best_time", 0f);
        if (seconds > best)
        {
            PlayerPrefs.SetFloat("best_time", seconds);
            PlayerPrefs.Save();
        }
    }
}
