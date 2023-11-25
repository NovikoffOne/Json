using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CubeData
{
    public List<Color> _colors;
    public List<PixelData> _data;
    public float elementScaleFactor;
    public float imageScaleFactor;
    public bool isMirror;
    public Vector3 Offset;

    [Serializable]
    public struct PixelData
    {
        public Vector3 position;
        public int colorIndex;
    }
}

[Serializable]
public class Offset
{
    public float x;
    public float y;
    public float z;
}

[Serializable]
public class _Colors
{
    public float r;
    public float g;
    public float b;
    public float a;
}

[Serializable]
public class _Data
{
    public Position position;
    public int colorIndex;
}

[Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
}
