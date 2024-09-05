using UnityEngine;
namespace GameData.MyScripts
{
    public static class Constants
    {
        public const string CardImageString = "CardImage",
            CardsGridString = "CardsGrid",
            CardIconString = "CardIcon",
            CardHideString = "cardHide",
            CardShowString = "cardShow",
            DisableCardString = "disableCard",
            CurrentLevelString = "CurrentLevel",
            CardsMatchingScene = "CardsMatching",
            SoundString = "Sound",
            LevelPlayingStateString = "LevelPlayingState";

        public static string[] LevelNames = {
            "CardsGrid (2, 2)",
            "CardsGrid (3, 3)",
            "CardsGrid (4, 4)",
            "CardsGrid (5, 6)",
            "CardsGrid (8, 8)"
        };
    }
    public static class PlayerPrefsHandler
    {
        public static void SetLevelStatePref(int newValue)
        {
            PlayerPrefs.SetInt(Constants.LevelPlayingStateString + PlayerPrefs.GetInt(Constants.CurrentLevelString), newValue);
        }
        public static int GetLevelStatePref()
        {
            return PlayerPrefs.GetInt(
                Constants.LevelPlayingStateString + PlayerPrefs.GetInt(Constants.CurrentLevelString), 0);
        }
    }
}