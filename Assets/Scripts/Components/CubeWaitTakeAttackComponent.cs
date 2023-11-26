using BlackECS.Components;
using UnityEngine;

public class CubeWaitTakeAttackComponent : IComponent
{
    public ComponentDataField<Cube> view;

    public PoolCubes<Cube> pool;
}
