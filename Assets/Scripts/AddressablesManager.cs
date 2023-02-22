using System;
using System.Threading.Tasks;
using Constructor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets.ResourceLocators;

// https://fvh1-fm.sweb.ru/files/Content/Characters/
public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceT<CharacterVisualConfig> characterVisualConfig;
    
    public void Init(Action callback)
    {
        Debug.Log("Init Addressables...");
        Addressables.InitializeAsync().Completed += (info) => callback.Invoke();
    }

    public async Task<CharacterVisualConfig> LoadCharacterVisual()
    {
        AsyncOperationHandle<CharacterVisualConfig> handle = characterVisualConfig.LoadAssetAsync();
            
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded) return handle.Result;
        
        return null;
    }

    private void OnAddressablesInitialized(AsyncOperationHandle<IResourceLocator> obj)
    {
        
    }
}
