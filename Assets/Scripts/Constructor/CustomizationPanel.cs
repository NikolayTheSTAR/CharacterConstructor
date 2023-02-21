using System;
using System.Collections.Generic;
using Game;
using TheSTAR.Utility;
using UnityEngine;
using Zenject;

namespace Constructor
{
    /// <summary>
    /// Panel in ConstructorScreen with setting lines
    /// </summary>
    public class CustomizationPanel : MonoBehaviour
    {
        [SerializeField] private SettingLine[] settings = new SettingLine[1];

        [Inject] private GameController _gameController;

        public void Init(CharacterVisual visual, Action<CharacterLayerType> onPreviousClick, Action<CharacterLayerType> onNextClick)
        {
            bool isAvailable = false;
            
            for (var i = 0; i < settings.Length; i++)
            {
                var setting = settings[i];
                if (setting == null) continue;
                
                setting.Init((CharacterLayerType)i, onPreviousClick, onNextClick);
                
                isAvailable = visual.IsAvailableToSetting((CharacterLayerType)i);
                
                if (isAvailable) setting.gameObject.SetActive(true);
                else
                {
                    switch (_gameController.GameConfig.ShowingCustomization)
                    {
                        case GameConfig.ShowingCustomizationType.ShowAllSettings:
                            setting.gameObject.SetActive(true);
                            setting.SetArrowsView(true);
                            break;
                            
                        case GameConfig.ShowingCustomizationType.ShowPartialUnavailableSettings:
                            setting.gameObject.SetActive(true);
                            setting.SetArrowsView(false);
                            break;
                        
                        case GameConfig.ShowingCustomizationType.DeactivateUnavailableSettings:
                            setting.gameObject.SetActive(false);
                            break;
                    }
                }
            }
        }
    }
}