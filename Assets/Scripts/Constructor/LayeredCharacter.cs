using System;
using TheSTAR.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace Constructor
{
    public class LayeredCharacter : MonoBehaviour
    {
        [SerializeField]
        private CharacterLayer[] layers = new CharacterLayer[1];
        
        public void Init()
        {
            var layerTypes = EnumUtility.GetValues<CharacterLayerType>();

            for (var l = 0; l < layerTypes.Length && l < layers.Length; l++)
            {
                var layer = layers[l];
                if (layer == null) continue;
                
                layer.Init(layerTypes[l]);
            }
        }
    }

    public enum CharacterLayerType
    {
        Body,
        Clothing,
        Emotion,
        Hairstyle
    }
}