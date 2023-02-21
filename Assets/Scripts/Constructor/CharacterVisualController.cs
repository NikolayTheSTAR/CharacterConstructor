using System;
using UnityEngine;

namespace Constructor
{
    public class CharacterVisualController : MonoBehaviour
    {
        private CharacterType currentCharacterType;
        private CharacterVisual visual;

        public string ConfigPath(CharacterType characterType) => $"Configs/Characters/{characterType.ToString()}";
        
        public CharacterVisual LoadArt(CharacterType characterType)
        {
            visual = Resources.Load<CharacterVisualConfig>(ConfigPath(characterType)).Visual;
            currentCharacterType = characterType;

            return visual;
        }
    }
}