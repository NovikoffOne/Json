using BlackECS.Components;
using UnityEngine;

public class CubeWaitTakeAttackComponent : IComponent
{
    public ComponentDataField<Transform> Transform;

    public PoolCubes<Cube> pool;
}
