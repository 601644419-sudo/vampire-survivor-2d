#!/bin/bash
mkdir -p Assets/Audio
# 使用 Google Actions 声音库的示例短音效
curl -L -o Assets/Audio/pickup.ogg https://actions.google.com/sounds/v1/cartoon/wood_plank_flicks.ogg
curl -L -o Assets/Audio/hit.ogg https://actions.google.com/sounds/v1/alarms/beep_short.ogg
curl -L -o Assets/Audio/bgm.ogg https://actions.google.com/sounds/v1/ambiences/inside_a_small_room.ogg

echo "已下载占位音效到 Assets/Audio/，请在 Unity 中刷新 Assets" 
