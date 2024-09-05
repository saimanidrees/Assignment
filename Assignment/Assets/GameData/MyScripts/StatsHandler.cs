using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class StatsHandler : MonoBehaviour
    {
        private int _turnsCount = 0, _scoreCount = 0; // To store values
        [SerializeField] private Text turnsText, scoreText; // Texts references
        private const string TurnsString = "Turns: ", ScoreString = "Score: "; // Constants
        private void OnEnable()
        {
            EventsManager.OnTurnsIncreases += IncreaseTurnsCounter;
            EventsManager.OnScoreIncreases += IncreaseScoreCounter;
        }
        private void OnDisable()
        {
            EventsManager.OnTurnsIncreases -= IncreaseTurnsCounter;
            EventsManager.OnScoreIncreases -= IncreaseScoreCounter;
        }
        private void IncreaseTurnsCounter()
        {
            _turnsCount++;
            turnsText.text = TurnsString + _turnsCount;
        }
        private void ResetTurnsCounter()
        {
            _turnsCount = 0;
            turnsText.text = TurnsString + _turnsCount;
        }
        private void IncreaseScoreCounter()
        {
            _scoreCount++;
            scoreText.text = ScoreString + _scoreCount;
            if(_scoreCount >= LevelsHandler.ScoreToAchieve)
                EventsManager.InvokeOnLevelEnd();
        }
        private void ResetScoreCounter()
        {
            _scoreCount = 0;
            scoreText.text = ScoreString + _scoreCount;
        }
    }
}