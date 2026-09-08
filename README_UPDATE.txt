README — 更新：默认解锁规则与运行说明

已更新：默认解锁规则为生存时间达到 60 秒解锁首个角色（在 GameManager 中可修改 unlockTime 与 unlockCharacterId）。

运行/测试步骤（更新）
- 在运行 SceneBuilder 生成场景前，请先运行下面两个脚本以确保占位资源存在：
  - 贴图（PowerShell）: powershell -ExecutionPolicy Bypass -File .\Assets\Tools\download_assets.ps1
  - 音频（PowerShell）: powershell -ExecutionPolicy Bypass -File .\Assets\Tools\download_audio.ps1
- 音频现在会下载到 Assets/Resources/Audio/，AudioManager 会在运行时通过 Resources.Load 加载并播放 BGM/SFX。

解锁与 UI
- 默认：生存 >= 60s 自动解锁 unlockCharacterId（默认 "char_01"）。解锁信息保存在 PlayerPrefs。
- UI 会在屏幕左上显示生存时间、击杀数与已拾取道具统计。

