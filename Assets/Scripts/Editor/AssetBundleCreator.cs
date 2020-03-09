#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleCreator : MonoBehaviour {

    [MenuItem("Assets/Build Asset Bundle")]
    static void BuildBuildes()
    {
        string dir = "AssetBundles";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        var options = BuildAssetBundleOptions.None;
//        var target = BuildTarget.StandaloneLinux64;
        var target = BuildTarget.Android;
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", options, target);
        Debug.Log("AssetBudles generated");
    }
}
#endif