using System;
using System.Collections.Generic;
using UnityEngine;
using Constructor;
using TheSTAR.Utility;

namespace GUI
{
    public class ConstructorScreen : MonoBehaviour
    {
        [SerializeField] private LayeredCharacter layeredCharacter;
        [SerializeField] private CustomizationPanel customizationPanel;
        
        private Dictionary<CharacterLayerType, int> _settingData;

        private void Start()
        {
            layeredCharacter.Init();
            customizationPanel.Init(SetPreviousElement, SetNextElement);
            
            _settingData = new Dictionary<CharacterLayerType, int>();
            var layerTypes = EnumUtility.GetValues<CharacterLayerType>();
            for (var i = 0; i < layerTypes.Length; i++) _settingData.Add((CharacterLayerType)i, 0);
        }

        private void SetPreviousElement(CharacterLayerType layerType)
        {
            _settingData[layerType]--;
            Debug.Log(_settingData[layerType].ToString());
        }
        
        private void SetNextElement(CharacterLayerType layerType)
        {
            _settingData[layerType]++;
            Debug.Log(_settingData[layerType].ToString());
        }
    }
}