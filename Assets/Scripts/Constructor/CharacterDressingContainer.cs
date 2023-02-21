using System;
using UnityEngine;

namespace Constructor
{
    public class CharacterDressingContainer : MonoBehaviour
    {
        [SerializeField] private LayeredCharacter character;
        [SerializeField] private Transform rightDot;

        private int _dressLeanTweenID = -1;
        private bool _dressing = false;
        
        private const float MoveTime = 0.5f;

        public bool Dressing => _dressing;

        [ContextMenu("AnimateDress")]
        public void AnimateDress(Action dressAction)
        {
            if (_dressing) return;
            
            if (_dressLeanTweenID != -1)
            {
                LeanTween.cancel(_dressLeanTweenID);
                _dressLeanTweenID = -1;
            }
            
            _dressLeanTweenID =
            LeanTween.move(character.gameObject, rightDot, MoveTime).setOnComplete(() =>
            {
                dressAction?.Invoke();
                _dressLeanTweenID = LeanTween.move(character.gameObject, transform, MoveTime).setOnComplete(() =>
                {
                    _dressLeanTweenID = -1;
                    _dressing = false;
                }).id;
            }).id;

            _dressing = true;
        }
    }
}