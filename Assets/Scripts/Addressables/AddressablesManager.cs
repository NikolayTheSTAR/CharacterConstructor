using System.Threading.Tasks;
using Constructor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Addressables
{
    public class AddressablesManager : MonoBehaviour
    {
        [SerializeField] private AssetReferenceT<CharacterVisualConfig> characterVisualConfig;
    
        public async Task Init()
        {
            Debug.Log("Init Addressables...");
        
            AsyncOperationHandle handle =UnityEngine.AddressableAssets.Addressables.InitializeAsync();
            await handle.Task;
        }

        public async Task<CharacterVisualConfig> LoadCharacterVisual()
        {
            var handle = characterVisualConfig.LoadAssetAsync();
            await handle.Task;
            return handle.Status == AsyncOperationStatus.Succeeded ? handle.Result : null;
        }
    }
}
