using System;
using UnityEngine;
namespace GameData.MyScripts
{
    public class EventsManager : MonoBehaviour
    {
        public static event Action<Card> OnCardSelect;
        public static event Action<Card> OnCardCheck;
        public static event Action<bool> OnClickAblesLimitReached;
        public static event Action OnTurnsIncreases;
        public static event Action OnTurnsResets;
        public static event Action OnScoreIncreases;
        public static event Action OnScoreResets;
        public static event Action OnSettingHighScore;
        public static event Action OnLevelEnd;
        public static void InvokeOnCardSelection(Card card)
        {
            OnCardSelect?.Invoke(card);
        }
        public static void InvokeOnCardCheck(Card card)
        {
            OnCardCheck?.Invoke(card);
        }
        public static void InvokeOnClickAblesLimitReached(bool flag)
        {
            OnClickAblesLimitReached?.Invoke(flag);
        }
        public static void InvokeOnTurnsIncreases()
        {
            OnTurnsIncreases?.Invoke();
        }
        public static void InvokeOnTurnsResets()
        {
            OnTurnsResets?.Invoke();
        }
        public static void InvokeOnScoreIncreases()
        {
            OnScoreIncreases?.Invoke();
        }
        public static void InvokeOnScoreResets()
        {
            OnScoreResets?.Invoke();
        }
        public static void InvokeOnSettingHighScore()
        {
            OnSettingHighScore?.Invoke();
        }
        public static void InvokeOnLevelEnd()
        {
            OnLevelEnd?.Invoke();
        }
    }
}