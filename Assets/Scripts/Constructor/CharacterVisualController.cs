using UnityEngine;

namespace Constructor
{
    public class CharacterVisualController : MonoBehaviour
    {
        private CharacterType currentCharacterType;
        private CharacterVisualConfig currentVisualConfig;

        public string ConfigPath(CharacterType characterType)
        {
            return $"Configs/Characters/{characterType.ToString()}";
        }
        
        public void LoadArt(CharacterType characterType)
        {
            currentVisualConfig = Resources.Load<CharacterVisualConfig>(ConfigPath(characterType));
            currentCharacterType = characterType;
            
            Debug.Log("Kits count: " + currentVisualConfig.Kits.Length);
        }
    }
}