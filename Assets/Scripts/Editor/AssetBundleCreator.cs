using UnityEditor;

public static class AssetBundleCreator
{
    private const string AssetBundlesPath = "Assets/AssetBundles";
        
    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(AssetBundlesPath, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}