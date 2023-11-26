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
