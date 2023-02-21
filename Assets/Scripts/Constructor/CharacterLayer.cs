using UnityEngine;
using UnityEngine.UI;

namespace Constructor
{
    /// <summary>
    /// One layer of LayeredCharacter
    /// </summary>
    public class CharacterLayer : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        private CharacterLayerType _layerType;

        public void Init(CharacterLayerType layerType)
        {
            _layerType = layerType;
        }

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}