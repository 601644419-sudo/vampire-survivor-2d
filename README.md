# vampire-survivor-2d

这是一个 Unity 2D 像素风肉鸽原型的仓库（开箱即玩）。

已完成：
- 核心玩法脚本（玩家、敌人、子弹、刷怪、拾取、全局管理）
- 占位素材下载脚本（图片与音频）
- 编辑器脚本：SceneBuilder（可在 Unity Editor -> Tools -> Build Starter Scene 一键生成场景与预制体）
- 简单 UI 管理脚本（UIManager）

快速开始（Windows，或其他平台）
1) 安装 Unity（推荐 2021.3 LTS）并打开 Unity Hub。
2) 克隆或下载本仓库：
   git clone https://github.com/601644419-sudo/vampire-survivor-2d.git
3) 进入项目根目录后，先下载占位贴图与音效：
   - 在 PowerShell (Windows): powershell -ExecutionPolicy Bypass -File .\Assets\Tools\download_assets.ps1
   - 在 Bash (macOS/Linux): bash Assets/Tools/download_assets.sh
   - 下载占位音效：
     - PowerShell: powershell -ExecutionPolicy Bypass -File .\Assets\Tools\download_audio.ps1
     - Bash: bash Assets/Tools/download_audio.sh
4) 在 Unity Hub 中点击 Add，选择项目文件夹并打开。
5) 在 Unity 的菜单栏选择 Tools -> Build Starter Scene（该菜单由 Assets/Editor/SceneBuilder.cs 提供），脚本会自动生成场景、预制体并保存为 Assets/Scenes/Main.unity。
6) 在 Project 窗口打开 Assets/Scenes/Main.unity 并按 Play 试玩。

说明：
- SceneBuilder 会尝试把 Assets/Textures 下的 PNG 设为 Sprite 类型并生成 Player/Enemy/Projectile/Item 的预制体以及简单的 UI Canvas。如果你不希望自动化，请手动创建场景并按脚本中的说明挂载组件。
- 玩法与平衡都是示例；你可以在 Assets/Scripts 中修改 PlayerController、Enemy、EnemySpawner、ItemPickup、GameManager 等脚本来自定义数值和道具。

解锁与保存：
- GameManager 提供了 SaveUnlock/IsUnlocked/SaveBestTime 的示例方法，使用 PlayerPrefs 本地保存。

下一步：
- 我可以继续添加更多道具、角色解锁界面、按键提示、音效触发和示例角色数据表，并且整理一个用于生成 Windows 可执行的详细图文打包指南。如果你希望我继续，我会把更多示例道具与 UI 功能补齐并 push。 
