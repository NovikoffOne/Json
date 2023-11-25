using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using UnityEngine;
using UnityEngine.Scripting;
using static UnityEngine.JsonUtility;

public class JsonToString : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public CubeData WriteJsonFile(string path="Assets/Content/Json/knife_duck.json")
    {
        var jsonString = File.ReadAllText(path);

        var data = FromJson<CubeData>(jsonString);

        if(data != null)
        {
            Dispose();

            return data;
        }

        Dispose();

        return null;
    }
}
