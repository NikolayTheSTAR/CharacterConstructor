using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Constructor
{
    [CreateAssetMenu(menuName = "Data/CharacterVisual", fileName = "CharacterVisualConfig")]
    public class CharacterVisualConfig : ScriptableObject
    {
        [SerializeField] private CharacterVisual visual;

        public CharacterVisual Visual => visual;
    }

    [Serializable]
    public class CharacterVisual
    {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private CharacterLayerVisualKit[] layerKits = new CharacterLayerVisualKit[1];

        public bool IsAvailableToSetting(CharacterLayerType layerType)
        {
            var layerKit = Array.Find(layerKits, (info) => info.LayerType == layerType);
            return layerKit != null && layerKit.Sprites.Length > 1;
        }

        public CharacterLayerVisualKit GetLayerKit(CharacterLayerType layerType)
        {
            return Array.Find(layerKits, (info) => info.LayerType == layerType);
        }
    }
    
    [Serializable]
    public class CharacterLayerVisualKit
    {
        [SerializeField] private CharacterLayerType layerType;
        [SerializeField] private Sprite[] sprites = new Sprite[1];
        
        public CharacterLayerType LayerType => layerType;
        public Sprite[] Sprites => sprites;
    }

    public enum CharacterType
    {
        Naomi
    }
}