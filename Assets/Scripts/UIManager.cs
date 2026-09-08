using UnityEngine;
using UnityEngine.UI;

// 简单 UI 管理：显示生存时间、敌人击杀数、已拾取道具
public class UIManager : MonoBehaviour
{
    private Text timeText;
    private Text killsText;
    private Text pickupsText;

    void Awake()
    {
        // 运行时动态创建 UI 元素（如果还没有）
        var canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("UIManager：未找到 Canvas，UI 将不会显示。建议使用 SceneBuilder 生成场景或手动创建 Canvas。" );
            return;
        }

        GameObject timeGO = new GameObject("TimeText");
        timeGO.transform.SetParent(canvas.transform, false);
        timeText = timeGO.AddComponent<Text>();
        timeText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        timeText.alignment = TextAnchor.UpperLeft;
        timeText.rectTransform.anchoredPosition = new Vector2(10, -10);
        timeText.rectTransform.anchorMin = new Vector2(0,1);
        timeText.rectTransform.anchorMax = new Vector2(0,1);
        timeText.color = Color.white;

        GameObject killGO = new GameObject("KillsText");
        killGO.transform.SetParent(canvas.transform, false);
        killsText = killGO.AddComponent<Text>();
        killsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        killsText.alignment = TextAnchor.UpperLeft;
        killsText.rectTransform.anchoredPosition = new Vector2(10, -30);
        killsText.rectTransform.anchorMin = new Vector2(0,1);
        killsText.rectTransform.anchorMax = new Vector2(0,1);
        killsText.color = Color.white;

        GameObject puGO = new GameObject("PickupsText");
        puGO.transform.SetParent(canvas.transform, false);
        pickupsText = puGO.AddComponent<Text>();
        pickupsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        pickupsText.alignment = TextAnchor.UpperLeft;
        pickupsText.rectTransform.anchoredPosition = new Vector2(10, -50);
        pickupsText.rectTransform.anchorMin = new Vector2(0,1);
        pickupsText.rectTransform.anchorMax = new Vector2(0,1);
        pickupsText.color = Color.white;
    }

    void Update()
    {
        if (timeText != null)
        {
            float t = GameManager.Instance != null ? GameManager.Instance.GetSurviveTime() : 0f;
            timeText.text = $"生存时间: {t:F1}s";
        }
        if (killsText != null)
        {
            killsText.text = $"击杀数: {GameManager.Instance?.GetKills() ?? 0}";
        }
        if (pickupsText != null)
        {
            pickupsText.text = GameManager.Instance != null ? GameManager.Instance.GetPickupsText() : "拾取: -";
        }
    }
}
