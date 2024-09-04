using System.Collections.Generic;
using UnityEngine;
namespace GameData.MyScripts
{
    public class CardSaver : MonoBehaviour
    {
        private readonly Stack<Card> _cardIds = new Stack<Card>();
        private void OnEnable()
        {
            EventsManager.OnCardSelect += OnCardSelection;
        }
        private void OnDisable()
        {
            EventsManager.OnCardSelect -= OnCardSelection;
        }
        private void OnCardSelection(Card newCard)
        {
            if (_cardIds.Count == 0)
            {
                _cardIds.Push(newCard);
            }
            else
            {
                var card = _cardIds.Pop();
                EventsManager.OnCardCheck += newCard.GetCardCheckingCallBack();
                EventsManager.InvokeOnCardCheck(card);
            }
        }
    }
}