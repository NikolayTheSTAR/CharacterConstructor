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

        public void Init(CharacterVisual visual, Action<CharacterLayerType> onPreviousClick, Action<CharacterLayerType> onNextClick)
        {
            bool isAvailable = false;
            
            for (var i = 0; i < settings.Length; i++)
            {
                var setting = settings[i];
                if (setting == null) continue;

                isAvailable = visual.IsAvailableToSetting((CharacterLayerType)i);

                if (isAvailable)
                {
                    setting.gameObject.SetActive(true);
                    setting.Init((CharacterLayerType)i, onPreviousClick, onNextClick);
                }
                else setting.gameObject.SetActive(false);
            }
        }
    }
}