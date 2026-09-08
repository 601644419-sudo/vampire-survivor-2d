#!/bin/bash
# 下载占位音效到 Assets/Resources/Audio/ 以便 Resources.Load 在运行时可获取
mkdir -p Assets/Resources/Audio
curl -L -o Assets/Resources/Audio/pickup.ogg https://actions.google.com/sounds/v1/cartoon/wood_plank_flicks.ogg
curl -L -o Assets/Resources/Audio/hit.ogg https://actions.google.com/sounds/v1/alarms/beep_short.ogg
curl -L -o Assets/Resources/Audio/bgm.ogg https://actions.google.com/sounds/v1/ambiences/inside_a_small_room.ogg

echo "已下载占位音效到 Assets/Resources/Audio/，请在 Unity 中刷新 Assets" 
