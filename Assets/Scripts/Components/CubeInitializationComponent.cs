using BlackECS.Components;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitializationComponent : IComponent
{
    public ComponentDataField<Vector3> position;
    public ComponentDataField<Transform> transform;
    public ComponentDataField<Renderer> renderer;
    public ComponentDataField<int> colorIndex;
    public ComponentDataField<Vector3> offset;

    public PoolCubes<Cube> pool;
    public List<Color> colors;
}
