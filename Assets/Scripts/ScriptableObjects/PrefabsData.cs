using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsData", menuName = "Scriptable Object/Prefabs Data", order = 51)]
public class PrefabsData : ScriptableObject
{
    public MenuView MENU_VIEW;
    public GameView GAME_VIEW;
    public CurrentSettingsView CURRENT_SETTINGS_VIEW;

    public SpawnView SPAWN_VIEW;
}
