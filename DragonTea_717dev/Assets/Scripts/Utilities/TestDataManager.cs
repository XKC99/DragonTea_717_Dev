using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;


[Serializable]
public class TestData
{
    public int i;
    public float f;
    public string str;
    //public Card card;
}

public class TestDataManager : Singleton<TestDataManager>
{
    
    private TestData td = new();

    public void Save() 
    {
        // 装配数据
        td.i = 233;
        // json化
        string jsonStr = JsonUtility.ToJson(td);
        // 写入文件
        File.WriteAllText(Application.persistentDataPath + "/test.json", jsonStr);
    }

    public void Load() 
    {
        // 读取文件
        string jsonStr = File.ReadAllText(Application.persistentDataPath + "/test.json");
        // 反序列化
        td = JsonUtility.FromJson<TestData>(jsonStr);
        // 打印数据
        Debug.Log(td.i);    

    }/*  */

}
