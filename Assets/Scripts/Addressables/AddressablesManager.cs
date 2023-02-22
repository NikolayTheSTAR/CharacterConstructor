using System;
using System.Threading.Tasks;
using Constructor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Addressables
{
    public class AddressablesManager : MonoBehaviour
    {
        [SerializeField] private AddressableCharacter[] addressableCharacters = new AddressableCharacter[1];
    
        public async Task Init()
        {
            Debug.Log("Init Addressables...");
        
            AsyncOperationHandle handle =UnityEngine.AddressableAssets.Addressables.InitializeAsync();
            await handle.Task;
        }

        public async Task<CharacterVisualConfig> LoadCharacterVisual(CharacterType characterType)
        {
            var character = Array.Find(addressableCharacters, (info) => info.CharacterType == characterType);
            
            var handle = character.CharacterVisualConfig.LoadAssetAsync();
            await handle.Task;
            return handle.Status == AsyncOperationStatus.Succeeded ? handle.Result : null;
        }

        [Serializable]
        public class AddressableCharacter
        {
            [SerializeField] private CharacterType characterType;
            [SerializeField] private AssetReferenceT<CharacterVisualConfig> characterVisualConfig;

            public CharacterType CharacterType => characterType;
            public AssetReferenceT<CharacterVisualConfig> CharacterVisualConfig => characterVisualConfig;
        }
    }
}
