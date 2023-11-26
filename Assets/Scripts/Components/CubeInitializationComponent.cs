using BlackECS.Components;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitializationComponent : IComponent
{
    public ComponentDataField<Vector3> position;
    public ComponentDataField<Cube> view;
    public ComponentDataField<Color> color;

    public PoolCubes<Cube> Pool { get; }

    public CubeInitializationComponent(PoolCubes<Cube> pool)
    {
        Pool = pool;
    }
}
