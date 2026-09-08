# PowerShell 版本：Windows
New-Item -ItemType Directory -Force -Path "Assets/Textures" | Out-Null
Invoke-WebRequest -Uri "https://via.placeholder.com/64x64.png?text=Player" -OutFile "Assets/Textures/player.png"
Invoke-WebRequest -Uri "https://via.placeholder.com/64x64.png?text=Enemy" -OutFile "Assets/Textures/enemy.png"
Invoke-WebRequest -Uri "https://via.placeholder.com/32x32.png?text=Item" -OutFile "Assets/Textures/item.png"
Write-Host "已下载占位贴图到 Assets/Textures/，请在 Unity 中刷新 Assets"
