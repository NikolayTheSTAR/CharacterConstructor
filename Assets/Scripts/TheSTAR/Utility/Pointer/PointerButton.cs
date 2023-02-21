using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TheSTAR.Utility.Pointer
{
    public class PointerButton : Pointer
    {
        [SerializeField] protected PointerButtonInfo info = new PointerButtonInfo();

        protected virtual PointerButtonInfo CurrentInfo => info;

        private Action _clickAction;
        private Action _enterAction;
        private Action _exitAction;
        private bool _isEnter = false;
        private bool _isDown = false;
        private bool _isInteractalbe = true;

        private void Start() 
        {
            InitPointer(
                (pointer) => OnButtonDown(),
                null,
                (pointer) => OnButtonUp(),
                (pointer) => OnButtonEnter(),
                (pointer) => OnButtonExit());
        }

        public void Init(Action clickAction, Action enterAction = null, Action exitAction = null)
        {
            _clickAction = clickAction;

            _enterAction = enterAction;
            _exitAction = exitAction;
        }

        private void OnButtonEnter()
        {
            if (!_isInteractalbe) return;
            
            _isEnter = true;

            UpdateVisual();

            _enterAction?.Invoke();
        }

        private void OnButtonExit()
        {            
            if (!_isInteractalbe) return;
            
            _isEnter = false;

            UpdateVisual();

            _exitAction?.Invoke();
        }

        private void OnButtonDown()
        {
            if (!_isInteractalbe) return;
            
            _isDown = true;

            UpdateVisual();
        }

        private void OnButtonUp()
        {
            if (!_isInteractalbe) return;
            if (_isEnter) _clickAction?.Invoke();

            _isDown = false;

            UpdateVisual();
        }

        private void OnDisable()
        {
            _isEnter = false;
            _isDown = false;
            UpdateVisual();
        }

        public void SetInteractalbe(bool value)
        {
            _isInteractalbe = value;

            UpdateVisual();
        }

        protected void UpdateVisual()
        {
            if (!CurrentInfo.UseChangeSprite) return;

            if (!gameObject.activeInHierarchy || !_isInteractalbe)
            {
                CurrentInfo.Img.sprite = CurrentInfo.IdleSprite;
                return;
            }

            if (_isEnter) CurrentInfo.Img.sprite = _isDown ? CurrentInfo.PressSprite : CurrentInfo.SelectSprite;
            else CurrentInfo.Img.sprite = CurrentInfo.IdleSprite;
        }

        [Serializable]
        public struct PointerButtonInfo
        {
            [Space, SerializeField] private bool useChangeSprite;
            [ShowIf("useChangeSprite"), SerializeField] private Image img;
            [ShowIf("useChangeSprite"), SerializeField] private Sprite idleSprite;
            [ShowIf("useChangeSprite"), SerializeField] private Sprite selectSprite;
            [ShowIf("useChangeSprite"), SerializeField] private Sprite pressSprite;
            
            public bool UseChangeSprite => useChangeSprite;
            public Image Img => img;
            public Sprite IdleSprite => idleSprite;
            public Sprite SelectSprite => selectSprite;
            public Sprite PressSprite => pressSprite;
        }
    }
}