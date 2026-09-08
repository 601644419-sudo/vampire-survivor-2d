using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Editor helper: 生成一个可开箱即玩的场景和预制体。
// 使用前请先运行 Assets/Tools/download_assets.ps1 或 .sh 下载占位纹理到 Assets/Textures/
public class SceneBuilder
{
    [MenuItem("Tools/Build Starter Scene")]
    public static void BuildScene()
    {
        // 创建新场景
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        // 确保文件夹存在
        System.IO.Directory.CreateDirectory("Assets/Prefabs");
        System.IO.Directory.CreateDirectory("Assets/Scenes");

        // 设置纹理导入为 Sprite 并 Reimport
        string[] texPaths = new string[] { "Assets/Textures/player.png", "Assets/Textures/enemy.png", "Assets/Textures/item.png" };
        foreach (var p in texPaths)
        {
            if (System.IO.File.Exists(p))
            {
                var importer = AssetImporter.GetAtPath(p) as TextureImporter;
                if (importer != null)
                {
                    importer.textureType = TextureImporterType.Sprite;
                    importer.SaveAndReimport();
                }
            }
            else
            {
                Debug.LogWarning($"纹理不存在: {p}. 请先运行 Assets/Tools/download_assets 脚本。");
            }
        }

        // 加载 Sprite
        Sprite playerSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Textures/player.png");
        Sprite enemySprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Textures/enemy.png");
        Sprite itemSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Textures/item.png");

        // 创建 GameManager
        GameObject gm = new GameObject("GameManager");
        gm.AddComponent<GameManager>();

        // 创建 Player
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        var pr = player.AddComponent<SpriteRenderer>();
        pr.sprite = playerSprite;
        var rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        player.AddComponent<CircleCollider2D>();
        var pc = player.AddComponent<PlayerController>();

        // firePoint
        GameObject fp = new GameObject("FirePoint");
        fp.transform.parent = player.transform;
        fp.transform.localPosition = new Vector3(0, 0.5f, 0);
        pc.firePoint = fp.transform;

        // Projectile prefab
        GameObject proj = new GameObject("Projectile");
        var psr = proj.AddComponent<SpriteRenderer>();
        psr.sprite = itemSprite;
        var prb = proj.AddComponent<Rigidbody2D>();
        prb.gravityScale = 0;
        var pcol = proj.AddComponent<CircleCollider2D>();
        pcol.isTrigger = true;
        var projScript = proj.AddComponent<Projectile>();

        string projPath = "Assets/Prefabs/Projectile.prefab";
        PrefabUtility.SaveAsPrefabAsset(proj, projPath);
        GameObject projPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(projPath);
        Object.DestroyImmediate(proj);

        // 将 projectilePrefab 赋给 PlayerController
        pc.projectilePrefab = projPrefab;

        // Enemy prefab
        GameObject enemy = new GameObject("Enemy");
        enemy.tag = "Enemy";
        var esr = enemy.AddComponent<SpriteRenderer>();
        esr.sprite = enemySprite;
        var erb = enemy.AddComponent<Rigidbody2D>();
        erb.gravityScale = 0;
        var ecol = enemy.AddComponent<CircleCollider2D>();
        var enemyScript = enemy.AddComponent<Enemy>();

        string enemyPath = "Assets/Prefabs/Enemy.prefab";
        PrefabUtility.SaveAsPrefabAsset(enemy, enemyPath);
        GameObject enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(enemyPath);
        Object.DestroyImmediate(enemy);

        // ItemPickup prefab
        GameObject item = new GameObject("ItemPickup");
        var isr = item.AddComponent<SpriteRenderer>();
        isr.sprite = itemSprite;
        var icb = item.AddComponent<CircleCollider2D>();
        icb.isTrigger = true;
        var itemScript = item.AddComponent<ItemPickup>();

        string itemPath = "Assets/Prefabs/ItemPickup.prefab";
        PrefabUtility.SaveAsPrefabAsset(item, itemPath);
        GameObject itemPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(itemPath);
        Object.DestroyImmediate(item);

        // 把 itemPickupPrefab 引用到 GameManager
        gm.GetComponent<GameManager>().itemPickupPrefab = itemPrefab;

        // EnemySpawner
        GameObject spawner = new GameObject("EnemySpawner");
        var sp = spawner.AddComponent<EnemySpawner>();
        sp.enemyPrefab = enemyPrefab;
        spawner.transform.position = Vector3.zero;

        // 创建简单 UI Canvas
        GameObject canvasGO = new GameObject("Canvas");
        var canvas = canvasGO.AddComponent<UnityEngine.Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<UnityEngine.UI.CanvasScaler>();
        canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

        // UIManager
        GameObject ui = new GameObject("UIManager");
        ui.transform.parent = canvasGO.transform;
        var uiMgr = ui.AddComponent<UIManager>();

        // 保存场景
        string scenePath = "Assets/Scenes/Main.unity";
        EditorSceneManager.SaveScene(scene, scenePath);
        AssetDatabase.Refresh();

        Debug.Log("已生成场景和预制体。请在 Project 窗口检查 Assets/Prefabs 与 Assets/Scenes/Main.unity。打开场景并按 Play 测试。");
    }
}
