using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

public class Hotfix : MonoBehaviour
{
    private LuaEnv luaEnv;

    private void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        luaEnv.DoString("require 'fish'");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"D:\BaiduNetdiskDownload\XLua\File\XluaProjects\PlayerGamePackage\"
+ filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDisable()
    {
        luaEnv.DoString("require'fishDispose'");
    }
}
