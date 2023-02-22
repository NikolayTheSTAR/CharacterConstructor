using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addressables;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Constructor
{
    public class CharacterVisualController : MonoBehaviour
    {
        private CharacterType _currentCharacterType;
        private Dictionary<CharacterType, CharacterVisual> _loadedCharacterVisuals;
        private CharacterVisual CurrentVisual => _loadedCharacterVisuals[_currentCharacterType];

        [Inject] private AddressablesManager _addressablesManager;

        public void Init()
        {
            _loadedCharacterVisuals = new Dictionary<CharacterType, CharacterVisual>();
        }
        
        public async Task<CharacterVisual> LoadArt(CharacterType characterType)
        {
            if (!_loadedCharacterVisuals.Keys.Contains(characterType))
            {
                var loadTask = _addressablesManager.LoadCharacterVisual(characterType);
                await loadTask;
                _loadedCharacterVisuals.Add(characterType, loadTask.Result.Visual);
            }
            
            _currentCharacterType = characterType;

            return CurrentVisual;
        }

        public Sprite GetSprite(CharacterLayerType layerType, int index) => CurrentVisual.GetLayerKit(layerType).Sprites[index];

        public int GetLayerSpritesCount(CharacterLayerType layerType) => CurrentVisual.GetLayerKit(layerType).Sprites.Length;
    }
}