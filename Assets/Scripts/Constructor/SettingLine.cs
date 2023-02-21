using System;
using TheSTAR.Utility.Pointer;
using UnityEngine;
using TMPro;

namespace Constructor
{
    /// <summary>
    /// Setting for one character layer type
    /// </summary>
    public class SettingLine : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private PointerButton buttonPrevious;
        [SerializeField] private PointerButton buttonNext;
        
        private CharacterLayerType _layerType;

        public void Init(CharacterLayerType layerType, Action<CharacterLayerType> onPreviousClick, Action<CharacterLayerType> onNextClick)
        {
            _layerType = layerType;
            
            title.text = layerType.ToString();
            
            buttonPrevious.Init(() => onPreviousClick(_layerType));
            buttonNext.Init(() => onNextClick(_layerType));
        }

        public void SetArrowsView(bool isVisible)
        {
            buttonPrevious.gameObject.SetActive(isVisible);
            buttonNext.gameObject.SetActive(isVisible);
        }
    }
}
