using UnityEngine;
namespace GameData.MyScripts
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 2)]
    public class LevelData : ScriptableObject
    {
        public int totalScore = 5; // Highest score can be achieved in a level
        public int rows = 3; // Number of rows in the grid
        public int columns = 3; // Number of columns in the grid
        public Vector2 imageSize = new Vector2(100, 100); // Size of each image
        public Vector2 childIconSize = new Vector2(20, 20); // Size of the child icon (width, height)
        public float spacing = 10f; // Space between the images
    }
}