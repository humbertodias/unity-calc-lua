using UnityEngine;
using XLua;

namespace XLuaTest
{

    [Hotfix]
    public class CalcService
    {
    
        [LuaCallCSharp]
        public double Add(double a, double b)
        {
            Debug.Log("Add " + a + " + " + b);
            return a + b;
        }

        public Vector3 Add(Vector3 a, Vector3 b)
        {
            return a + b;
        }
    }

}
