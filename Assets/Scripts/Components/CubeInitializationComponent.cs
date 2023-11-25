using BlackECS.Components;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitializationComponent : IComponent
{
    public ComponentDataField<Vector3> Position;
    public ComponentDataField<Transform> Transform;
    public ComponentDataField<Renderer> Renderer;
    public ComponentDataField<int> ColorIndex;
    public ComponentDataField<Vector3> offset;

    public List<Color> Color;
}
