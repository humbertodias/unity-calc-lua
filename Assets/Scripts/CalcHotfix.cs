using System;
using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using XLua;

public class CalcHotfix : MonoBehaviour
{
    /*
    void Start()
    {
        Debug.Log("Start hotfix");
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString("require 'calc'");
    }*/

    public InputField serverAssetBundle;
    private AssetBundle assetBundle;

    // Start is called before the first frame update
    public void ApplyLuaFix()
    {
        Debug.Log("DownLoad Script");
        // Start coroutine
        StartCoroutine(GetAssetBundle(ExcuteHotFix));
    }
    //-----------------------------【Download hot-resources from the server】-----------------------------
    IEnumerator GetAssetBundle(Action callBack)
    {
        string path = serverAssetBundle.text;
        Debug.Log("DownLoading: " + path);
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(path);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("DownLoad Err: " + www.error);
        }
        else
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(www);
            //Load downloaded lua script
            TextAsset hot = assetBundle.LoadAsset<TextAsset>("calc.lua.txt");
            //Save to local folder
            string newPath = Application.persistentDataPath + @"/calc.lua.txt";
            if (!File.Exists(newPath))
            {
                // If you do not actively release resources after Create, it will be occupied, and an error will be reported next time you open it, so you must add .Dispose ()
                File.Create(newPath).Dispose();
            }
            File.WriteAllText(newPath, hot.text);
            Debug.Log("Download resource succeeded！new Path : " + newPath);
            // After successful download, read and execute lua script
            callBack();
        }
    }

    //-----------------------------【Execute hot change script】-----------------------------
    public void ExcuteHotFix()
    {
        Debug.Log("Start executing hot change script calc");
        LuaEnv luaenv = new LuaEnv();
        luaenv.AddLoader(MyLoader);
        luaenv.DoString("require 'calc'");
    }

    // Custom Loader
    public byte[] MyLoader(ref string filePath)
    {
        // Reading downloaded script resources
        string newPath = Application.persistentDataPath + @"/" + filePath + ".lua.txt";
        Debug.Log("Execute script path：" + newPath);
        string txtString = File.ReadAllText(newPath);
        return System.Text.Encoding.UTF8.GetBytes(txtString);
    }



}
