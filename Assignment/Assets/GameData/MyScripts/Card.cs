using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace GameData.MyScripts
{
    public class Card : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private int _cardId;
        private Animator _animator;
        private bool _isCurrentlyClicked = false;
        public void SetCard(int newId, Animator animator, RuntimeAnimatorController newRuntimeAnimator)
        {
            _cardId = newId;
            _animator = animator;
            _animator.runtimeAnimatorController = newRuntimeAnimator;
        }
        public int GetCardId()
        {
            return _cardId;
        }
        public Action<Card> GetCardCheckingCallBack()
        {
            return CheckCard;
        }
        private void CheckCard(Card otherCard)
        {
            if (_cardId == otherCard.GetCardId())
            {
                DisableCard();
                otherCard.DisableCard();
            }
            else
            {
                Debug.Log("Checking Card");
                HideCard();
                otherCard.HideCard();
            }
            EventsManager.OnCardCheck -= otherCard.GetCardCheckingCallBack();
        }
        private void HideCard()
        {
            Debug.Log("HideCard");
            Invoke(nameof(HidingCard), 1.25f);
        }
        private void DisableCard()
        {
            _animator.Play("disableCard");
        }
        private void HidingCard()
        {
            _isCurrentlyClicked = false;
            _animator.Play("cardHide");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(_isCurrentlyClicked) return;
            _isCurrentlyClicked = true;
            _animator.Play("cardShow");
            EventsManager.InvokeOnCardSelection(this);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}