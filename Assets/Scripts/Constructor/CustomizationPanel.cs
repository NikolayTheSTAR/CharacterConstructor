using System;
using System.Collections.Generic;
using TheSTAR.Utility;
using UnityEngine;

namespace Constructor
{
    public class CustomizationPanel : MonoBehaviour
    {
        [SerializeField]
        private SettingLine[] settings = new SettingLine[1];

        

        public void Init(Action<CharacterLayerType> onPreviousClick, Action<CharacterLayerType> onNextClick)
        {
            var layerTypes = EnumUtility.GetValues<CharacterLayerType>();
            
            for (var i = 0; i < layerTypes.Length; i++)
            {
                // setting line
                
                var setting = settings[i];
                if (setting == null) continue;
                
                setting.Init(layerTypes[i], onPreviousClick, onNextClick);
            }
        }
    }
}