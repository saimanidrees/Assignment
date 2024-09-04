using UnityEngine;
namespace GameData.MyScripts
{
    public class LevelsHandler : MonoBehaviour
    {
        [SerializeField] private ImageGrid imageGrid;
        [SerializeField] private LevelData[] levelsData;
        private void Start()
        {
            Application.targetFrameRate = 60;
            LaunchLevel();
        }
        private void LaunchLevel()
        {
            var levelNo = PlayerPrefs.GetInt(Constants.CurrentLevelString);
            if (levelNo == 3)
            {
                Instantiate(Resources.Load(Constants.CardsGrid3By3String), imageGrid.transform);
            }
            else
            {
                imageGrid.CreateGridLayout(levelsData[levelNo]);
            }
        }
    }
}