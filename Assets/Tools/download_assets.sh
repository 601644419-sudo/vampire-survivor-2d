#!/bin/bash
# 简单脚本：下载占位贴图到 Assets/Textures
mkdir -p Assets/Textures
curl -L -o Assets/Textures/player.png "https://via.placeholder.com/64x64.png?text=Player"
curl -L -o Assets/Textures/enemy.png "https://via.placeholder.com/64x64.png?text=Enemy"
curl -L -o Assets/Textures/item.png "https://via.placeholder.com/32x32.png?text=Item"

echo "已下载占位贴图到 Assets/Textures/，请在 Unity 中刷新 Assets" 
