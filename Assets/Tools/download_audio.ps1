# PowerShell 版本：Windows
New-Item -ItemType Directory -Force -Path "Assets/Resources/Audio" | Out-Null
Invoke-WebRequest -Uri "https://actions.google.com/sounds/v1/cartoon/wood_plank_flicks.ogg" -OutFile "Assets/Resources/Audio/pickup.ogg"
Invoke-WebRequest -Uri "https://actions.google.com/sounds/v1/alarms/beep_short.ogg" -OutFile "Assets/Resources/Audio/hit.ogg"
Invoke-WebRequest -Uri "https://actions.google.com/sounds/v1/ambiences/inside_a_small_room.ogg" -OutFile "Assets/Resources/Audio/bgm.ogg"
Write-Host "已下载占位音效到 Assets/Resources/Audio/，请在 Unity 中刷新 Assets"
