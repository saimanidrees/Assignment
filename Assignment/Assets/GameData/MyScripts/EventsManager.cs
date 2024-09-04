using System;
using UnityEngine;
namespace GameData.MyScripts
{
    public class EventsManager : MonoBehaviour
    {
        public static event Action<Card> OnCardSelect;
        public static event Action<Card> OnCardCheck;
        public static event Action OnClickAblesLimitReached;
        public static void InvokeOnCardSelection(Card card)
        {
            OnCardSelect?.Invoke(card);
        }
        public static void InvokeOnCardCheck(Card card)
        {
            OnCardCheck?.Invoke(card);
        }
        public static void InvokeOnClickAblesLimitReached()
        {
            OnClickAblesLimitReached?.Invoke();
        }
    }
}