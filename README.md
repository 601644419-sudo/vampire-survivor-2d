# vampire-survivor-2d

这是一个 Unity 2D 像素风肉鸽原型的初始脚手架仓库。

目标：提供一个可以在本地打开、快速上手的 Unity 项目结构与主要脚本；占位素材可通过提供的脚本一键下载。

说明（简化）
- 推荐 Unity 版本：2021.3 LTS
- 打开步骤：
  1. 在 Unity Hub 新建（或打开）一个 2D 项目，Unity 版本选择 2021.3.x。
  2. 将本仓库克隆或下载 ZIP 并把 Assets 文件夹内容复制到你的 Unity 项目根目录下（覆盖提示请确认）。
  3. 在 Unity 中打开 Scene（Assets/Scenes/Main.unity） — 如果你没有看到场景，请在 Unity 中创建一个新场景并保存为 Assets/Scenes/Main.unity，然后按 README 中的指示手动添加对象（或运行下方脚本帮助创建）。
  4. 在 Unity 编辑器中运行（Play）进行试玩。

快速获取占位素材
- 我在 `Assets/Tools/download_assets.ps1`（Windows PowerShell）和 `Assets/Tools/download_assets.sh`（Linux/macOS）里放了脚本，运行后会下载占位图片到 `Assets/Textures/`。

下一个步骤
- 我已上传核心脚本（玩家、敌人、子弹、刷新器、道具与保存管理）。你可以先导入占位素材并在 Unity 中根据 README 创建 GameObjects（或告诉我，我可以继续把完整的场景文件和预制体上传）。

如果你希望我继续：
- 我可以把完整的 Unity 场景（Main.unity）、预制体（玩家、敌人、子弹、道具）以及小型音效/音乐上传，使项目开箱即玩；但那需要我生成并上传二进制资源（我可以把占位 PNG/音频文件通过下载脚本注入，或直接把小文件上传）。

---

README: 接下来我会把如何在 Unity 中快速搭建场景的步骤写清楚，已在仓库里。
