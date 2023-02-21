using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Constructor
{
    public class CharacterVisualController : MonoBehaviour
    {
        private CharacterType _currentCharacterType;
        private Dictionary<CharacterType, CharacterVisual> _loadedCharacterVisuals;
        private CharacterVisual CurrentVisual => _loadedCharacterVisuals[_currentCharacterType];

        public void Init()
        {
            _loadedCharacterVisuals = new Dictionary<CharacterType, CharacterVisual>();
        }
        
        private string ConfigPath(CharacterType characterType) => $"Configs/Characters/{characterType.ToString()}";
        
        public CharacterVisual LoadArt(CharacterType characterType)
        {
            if (!_loadedCharacterVisuals.Keys.Contains(characterType))
                _loadedCharacterVisuals.Add(characterType, Resources.Load<CharacterVisualConfig>(ConfigPath(characterType)).Visual);
            
            _currentCharacterType = characterType;

            return CurrentVisual;
        }

        public Sprite GetSprite(CharacterLayerType layerType, int index) => CurrentVisual.GetLayerKit(layerType).Sprites[index];

        public int GetLayerSpritesCount(CharacterLayerType layerType) => CurrentVisual.GetLayerKit(layerType).Sprites.Length;
    }
}