using System;
using System.Collections.Generic;
using BlackECS.Components;
using UnityEngine;

public class CubeTakeAttackComponent : IComponent
{
    public ComponentDataField<Vector3> direction;
    public ComponentDataField<Cube> view;
    public ComponentDataField<float> scaleForce;
    public ComponentDataField<float> speed;
    public ComponentDataField<float> timer;
    
    public PoolCubes<Cube> pool;
}
