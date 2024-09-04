using UnityEngine;
namespace GameData.MyScripts
{
    [CreateAssetMenu(fileName = "IconsInventory", menuName = "ScriptableObjects/IconsInventory", order = 1)]
    public class IconsInventory : ScriptableObject
    {
        public IconData[] iconsData; // Array of child icons
    }
    [System.Serializable]
    public class IconData
    {
        public Sprite sprite; // The icon sprite
        public int id; // Unique ID for this icon
    }
}