using System.Collections.Generic;
using UnityEngine;

// 全局游戏管理
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("预制体引用（在场景中拖拽）")]
    public GameObject itemPickupPrefab;

    [Header("解锁设置")]
    public string unlockCharacterId = "char_01";
    public float unlockTime = 60f; // 生存达到多少秒解锁

    private float startTime;
    private int enemiesKilled = 0;
    private bool unlocked = false;

    // 统计玩家已拾取的道具（id -> 次数/数值）
    private Dictionary<string, int> pickupsCounts = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        startTime = Time.time;

        // 如果已经解锁过，标记为已解锁
        if (IsUnlocked(unlockCharacterId)) unlocked = true;

        // 尝试播放 BGM（如果有 AudioManager）
        AudioManager.Instance?.PlayBGM();
    }

    void Update()
    {
        // 检查解锁条件（生存时间）
        if (!unlocked && GetSurviveTime() >= unlockTime)
        {
            unlocked = true;
            SaveUnlock(unlockCharacterId);
            Debug.Log($"解锁角色: {unlockCharacterId}");
            // 播放解锁音效（若存在）
            AudioManager.Instance?.PlaySFX("pickup");
        }
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;
    }

    public void OnPlayerPickup(string id, float value)
    {
        // 增加统计
        if (!pickupsCounts.ContainsKey(id)) pickupsCounts[id] = 0;
        pickupsCounts[id]++;

        // 播放拾取音效
        AudioManager.Instance?.PlaySFX("pickup");

        Debug.Log($"Player picked up {id} (+{value}). Total: {pickupsCounts[id]}");
    }

    public float GetSurviveTime()
    {
        return Time.time - startTime;
    }

    public int GetKills()
    {
        return enemiesKilled;
    }

    public string GetPickupsText()
    {
        if (pickupsCounts.Count == 0) return "拾取: -";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var kv in pickupsCounts)
        {
            sb.AppendFormat("{0} x{1}  ", kv.Key, kv.Value);
        }
        return sb.ToString();
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
