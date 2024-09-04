using UnityEngine;
namespace GameData.MyScripts
{
    public class Card : MonoBehaviour
    {
        private int _cardId;
        private Animator _animator;
        public Card(int newId, Animator newAnimator)
        {
            _cardId = newId;
            _animator = newAnimator;
        }
    }
}