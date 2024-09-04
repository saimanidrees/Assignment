using UnityEngine;
using UnityEngine.UI;
namespace GameData.MyScripts
{
    public class StatsHandler : MonoBehaviour
    {
        private int _turnsCount = 0, _scoreCount = 0; // To store values
        [SerializeField] private Text turnsText, scoreText, highScoreText; // Texts references
        private const string TurnsString = "Turns: ", ScoreString = "Score: ", HighScoreString = "HighScore: "; // Constants
        private void OnEnable()
        {
            EventsManager.OnTurnsIncreases += IncreaseTurnsCounter;
            EventsManager.OnTurnsResets += ResetTurnsCounter;
            EventsManager.OnScoreIncreases += IncreaseScoreCounter;
            EventsManager.OnScoreResets += ResetScoreCounter;
            EventsManager.OnSettingHighScore += SetHighScore;
        }
        private void OnDisable()
        {
            EventsManager.OnTurnsIncreases -= IncreaseTurnsCounter;
            EventsManager.OnTurnsResets -= ResetTurnsCounter;
            EventsManager.OnScoreIncreases -= IncreaseScoreCounter;
            EventsManager.OnScoreResets -= ResetScoreCounter;
            EventsManager.OnSettingHighScore -= SetHighScore;
        }
        private void IncreaseTurnsCounter()
        {
            _turnsCount++;
            turnsText.text = TurnsString + _turnsCount;
            SetHighScore();
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
        }
        private void ResetScoreCounter()
        {
            _scoreCount = 0;
            scoreText.text = ScoreString + _scoreCount;
        }
        private void SetHighScore()
        {
            if (_scoreCount <= PlayerPrefs.GetInt(Constants.HighScoreString)) return;
            PlayerPrefs.SetInt(Constants.HighScoreString, _scoreCount);
            highScoreText.text = HighScoreString + _scoreCount;
        }
    }
}