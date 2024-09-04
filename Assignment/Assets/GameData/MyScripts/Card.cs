using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace GameData.MyScripts
{
    public class Card : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private int cardId; // Card Id to compare
        private Animator _animator; // To Play animations
        private bool _isCurrentlyClicked = false, _isNotClickAble = false; // Flags to control clicking
        private void OnEnable()
        {
            EventsManager.OnClickAblesLimitReached += SetIsNotClickAble;
        }
        private void OnDisable()
        {
            EventsManager.OnClickAblesLimitReached -= SetIsNotClickAble;
        }
        public void SetCard(int newId, Animator animator, RuntimeAnimatorController newRuntimeAnimator)
        {
            cardId = newId;
            _animator = animator;
            _animator.runtimeAnimatorController = newRuntimeAnimator;
        }
        private int GetCardId()
        {
            return cardId;
        }
        public Action<Card> GetCardCheckingCallBack()
        {
            return CheckCard;
        }
        private void CheckCard(Card otherCard)
        {
            if (cardId == otherCard.GetCardId())
            {
                InvokeDisableCard();
                otherCard.InvokeDisableCard();
                EventsManager.InvokeOnScoreIncreases();
            }
            else
            {
                InvokeHideCard();
                otherCard.InvokeHideCard();
            }
            EventsManager.InvokeOnTurnsIncreases();
            EventsManager.OnCardCheck -= otherCard.GetCardCheckingCallBack();
            EventsManager.OnCardCheck -= GetCardCheckingCallBack();
            Invoke(nameof(InvokeClicksLimitReached), 1.5f);
        }
        private void InvokeHideCard()
        {
            Invoke(nameof(HideCard), 1.25f);
        }
        private void HideCard()
        {
            _animator.Play(Constants.CardHideString);
            _isCurrentlyClicked = false;
        }
        private void InvokeDisableCard()
        {
            Invoke(nameof(DisableCard), 1.25f);
        }
        private void DisableCard()
        {
            _animator.Play(Constants.DisableCardString);
            _isCurrentlyClicked = false;
        }
        private void SetIsNotClickAble(bool flag)
        {
            _isNotClickAble = flag;
        }
        private void InvokeClicksLimitReached()
        {
               EventsManager.InvokeOnClickAblesLimitReached(false);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(_isNotClickAble) return;
            if(_isCurrentlyClicked) return;
            _isCurrentlyClicked = true;
            if (!_animator) _animator = GetComponent<Animator>();
            _animator.Play(Constants.CardShowString);
            EventsManager.InvokeOnCardSelection(this);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}