using UnityEngine;
namespace GameData.MyScripts
{
    [CreateAssetMenu(fileName = "IconsData", menuName = "ScriptableObjects/IconsInventory", order = 1)]
    public class IconsInventory : ScriptableObject
    {
        public Sprite sprite; // The icon sprite
        public string id; // Unique ID for this icon
    }
}