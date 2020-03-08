using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CalcHotfix : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start hotfix");
        LuaEnv luaenv = new LuaEnv();
        /*        luaenv.DoString(@"
                    xlua.hotfix(CS.XLuaTest.CalcService,'Add',function(self, a, b)
                        print('LOL')
                        return a * b
                    end)");
                    */
        luaenv.DoString("require 'calc'");
    }

}
