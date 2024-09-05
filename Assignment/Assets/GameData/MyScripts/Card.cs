using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace GameData.MyScripts
{
    public class Card : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private int cardId; // Card Id to compare
        private Animator _animator; // To Play animations
        private bool _isCurrentlyClicked = false, _isNotClickAble = true; // Flags to control clicking
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
                if (LevelsHandler.IsPredefinedLevel())
                {
                    DataManager.Instance.SavePair(transform.GetSiblingIndex(), otherCard.transform.GetSiblingIndex());
                }
                InvokeDisableCard(1.25f);
                otherCard.InvokeDisableCard(1.25f);
                EventsManager.InvokeOnScoreIncreases();
                SoundController.Instance.PlayCorrectSelectionSound();
            }
            else
            {
                InvokeHideCard();
                otherCard.InvokeHideCard();
                SoundController.Instance.PlayWrongSelectionSound();
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
        public void InvokeDisableCard(float delay)
        {
            Invoke(nameof(DisableCard), 1.25f);
        }
        private void DisableCard()
        {
            if (!_animator) 
                _animator = GetComponent<Animator>();
            _animator.Play(Constants.DisableCardString);
            _isCurrentlyClicked = false;
        }
        public void SetIsNotClickAble(bool flag)
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
            SoundController.Instance.PlayBtnClickSound();
            if (!_animator) _animator = GetComponent<Animator>();
            _animator.Play(Constants.CardShowString);
            EventsManager.InvokeOnCardSelection(this);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
    }
}