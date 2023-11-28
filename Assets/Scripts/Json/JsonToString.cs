using System;
using System.IO;
using static UnityEngine.JsonUtility;

public class JsonToString : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public CubeData WriteJsonFile(string path = "Assets/Content/Json/knife_duck.json")
    {
        var jsonString = File.ReadAllText(path);

        var data = FromJson<CubeData>(jsonString);

        if (data != null)
        {
            Dispose();

            return data;
        }

        Dispose();

        return null;
    }
}
