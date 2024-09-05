using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace GameData.MyScripts
{
    public class LevelsHandler : MonoBehaviour
    {
        private enum LevelType
        {
            Predefined,
            RunTimeCreation
        }
        [SerializeField] private ImageGrid imageGrid;
        [SerializeField] private LevelData[] levelsData;
        [SerializeField] private GameObject levelSelection;
        public static int ScoreToAchieve = 5;
        private static LevelType _levelType;
        private readonly WaitForSeconds _endDelay = new WaitForSeconds(2f);
        private void OnEnable()
        {
            EventsManager.OnLevelEnd += LevelEnd;
        }
        private void OnDisable()
        {
            EventsManager.OnLevelEnd -= LevelEnd;
        }
        public void StartPredefinedLevel(int levelNo)
        {
            SoundController.Instance.PlayBtnClickSound();
            _levelType = LevelType.Predefined;
            levelSelection.SetActive(false);
            PlayerPrefs.SetInt(Constants.CurrentLevelString, levelNo);
            Instantiate(Resources.Load(Constants.LevelNames[levelNo]), imageGrid.transform);
            ScoreToAchieve = levelsData[levelNo].totalScore;
            if(PlayerPrefsHandler.GetLevelStatePref() == 0)
                DataManager.Instance.ResetJson(levelsData[levelNo].rows * levelsData[levelNo].columns);
        }
        public void CreateNewLevel(int levelNo)
        {
            SoundController.Instance.PlayBtnClickSound();
            _levelType = LevelType.RunTimeCreation;
            levelSelection.SetActive(false);
            PlayerPrefs.SetInt(Constants.CurrentLevelString, levelNo);
            imageGrid.CreateGridLayout(levelsData[levelNo]);
            ScoreToAchieve = levelsData[levelNo].totalScore;
        }
        public static bool IsPredefinedLevel()
        {
            return _levelType == LevelType.Predefined;
        }
        private void LevelEnd()
        {
            StartCoroutine(DelayForLevelEnd());
        }
        private IEnumerator DelayForLevelEnd()
        {
            var levelNo = PlayerPrefs.GetInt(Constants.CurrentLevelString);
            DataManager.Instance.ResetJson(levelsData[levelNo].rows * levelsData[levelNo].columns);
            SoundController.Instance.PlayGameCompleteSound();
            yield return _endDelay;
            SceneManager.LoadScene(Constants.CardsMatchingScene);
        }
    }
}