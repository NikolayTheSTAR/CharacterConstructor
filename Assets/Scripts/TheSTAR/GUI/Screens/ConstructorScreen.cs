using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Constructor;
using TheSTAR.Utility;
using Zenject;

namespace TheSTAR.GUI.Screens
{
    /// <summary>
    /// Character customization screen
    /// </summary>
    public class ConstructorScreen : GuiScreen
    {
        [SerializeField] private LayeredCharacter layeredCharacter;
        [SerializeField] private CustomizationPanel customizationPanel;
        [SerializeField] private CharacterDressingContainer dressContainer;

        [Inject] private CharacterVisualController _characterVisualController;
        
        private Dictionary<CharacterLayerType, int> _settingData;

        public async Task Init(CharacterType characterType)
        {
            var loadVisualTask = _characterVisualController.LoadArt(characterType);

            await loadVisualTask;
            
            layeredCharacter.Init(loadVisualTask.Result);
            customizationPanel.Init(loadVisualTask.Result, SetPreviousElement, SetNextElement);
            
            _settingData = new Dictionary<CharacterLayerType, int>();
            var layerTypes = EnumUtility.GetValues<CharacterLayerType>();
            for (var i = 0; i < layerTypes.Length; i++) _settingData.Add((CharacterLayerType)i, 0);
        }

        #region Dressing
        
        private void SetPreviousElement(CharacterLayerType layerType)
        {
            if (dressContainer.Dressing) return;
            
            var tempIndex = _settingData[layerType] - 1;
            if (tempIndex < 0) tempIndex = _characterVisualController.GetLayerSpritesCount(layerType) - 1;
            _settingData[layerType] = tempIndex;
            
            AnimateDress(layerType);
        }
        
        private void SetNextElement(CharacterLayerType layerType)
        {
            if (dressContainer.Dressing) return;
            
            var tempIndex = _settingData[layerType] + 1;
            if (tempIndex > _characterVisualController.GetLayerSpritesCount(layerType) - 1) tempIndex = 0;
            _settingData[layerType] = tempIndex;
            
            AnimateDress(layerType);
        }

        private void AnimateDress(CharacterLayerType layerType)
        {
            dressContainer.AnimateDress(() =>
            {
                var index = _settingData[layerType];
                var sprite = _characterVisualController.GetSprite(layerType, index);
                layeredCharacter.SetSprite(layerType, sprite);
            });
        }

        #endregion
    }
}