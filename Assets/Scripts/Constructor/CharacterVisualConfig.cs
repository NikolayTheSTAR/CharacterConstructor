using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Constructor
{
    [CreateAssetMenu(menuName = "Data/CharacterVisual", fileName = "CharacterVisualConfig")]
    public class CharacterVisualConfig : ScriptableObject
    {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private VisualKit[] kits = new VisualKit[1];

        public VisualKit[] Kits => kits;
        
        [Serializable]
        public class VisualKit
        {
            [SerializeField] private CharacterLayerType layerType;
            [SerializeField] private Sprite[] sprites = new Sprite[1];
        }
    }

    public enum CharacterType
    {
        Naomi
    }
}