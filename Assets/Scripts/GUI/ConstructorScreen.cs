using System;
using System.Collections.Generic;
using UnityEngine;
using Constructor;
using TheSTAR.Utility;
using Zenject;

namespace GUI
{
    public class ConstructorScreen : MonoBehaviour
    {
        [SerializeField] private LayeredCharacter layeredCharacter;
        [SerializeField] private CustomizationPanel customizationPanel;

        [Inject] private CharacterVisualController _characterVisualController;
        
        private Dictionary<CharacterLayerType, int> _settingData;

        private void Start()
        {
            Init(CharacterType.Naomi);
        }

        private void Init(CharacterType characterType)
        {
            var visual = _characterVisualController.LoadArt(characterType);
            
            layeredCharacter.Init();
            customizationPanel.Init(visual, SetPreviousElement, SetNextElement);
            
            _settingData = new Dictionary<CharacterLayerType, int>();
            var layerTypes = EnumUtility.GetValues<CharacterLayerType>();
            for (var i = 0; i < layerTypes.Length; i++) _settingData.Add((CharacterLayerType)i, 0);
        }

        private void SetPreviousElement(CharacterLayerType layerType)
        {
            _settingData[layerType]--;
        }
        
        private void SetNextElement(CharacterLayerType layerType)
        {
            _settingData[layerType]++;
        }
    }
}