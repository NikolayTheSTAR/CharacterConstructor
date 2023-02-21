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
        
        public void Init(CharacterVisual visual)
        {
            // init layers

            CharacterLayerType layerType;
            for (var i = 0; i < layers.Length && i < layers.Length; i++)
            {
                var layer = layers[i];
                if (layer == null) continue;

                layerType = (CharacterLayerType)i;
                layer.Init(layerType);
                layer.SetSprite(visual.GetLayerKit(layerType).Sprites[0]);
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