#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AssetBundleCreator : MonoBehaviour {

    static AssetBundleBuild[] build()
    {
        AssetBundleBuild[] build = new AssetBundleBuild[1];
        build[0] = new AssetBundleBuild();
        build[0].assetBundleName = "Button";
        build[0].assetNames = new string[1] { "Assets/Prefab/Button.prefab" };

        return build;
    }
    [MenuItem("Assets/Build Asset Bundle")]
    static void BuildBuildes()
    {
        var options = BuildAssetBundleOptions.None;
        var target = BuildTarget.StandaloneLinux64;
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", build(), options, target);
    }
}
#endif