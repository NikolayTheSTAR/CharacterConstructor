using System;
using UnityEngine;

namespace Constructor
{
    public class CharacterVisualController : MonoBehaviour
    {
        private CharacterType currentCharacterType;
        private CharacterVisual currentVisual;

        public string ConfigPath(CharacterType characterType) => $"Configs/Characters/{characterType.ToString()}";
        
        public CharacterVisual LoadArt(CharacterType characterType)
        {
            currentVisual = Resources.Load<CharacterVisualConfig>(ConfigPath(characterType)).Visual;
            currentCharacterType = characterType;

            return currentVisual;
        }

        public Sprite GetSprite(CharacterLayerType layerType, int index) => currentVisual.GetLayerKit(layerType).Sprites[index];

        public int GetLayerSpritesCount(CharacterLayerType layerType) => currentVisual.GetLayerKit(layerType).Sprites.Length;
    }
}