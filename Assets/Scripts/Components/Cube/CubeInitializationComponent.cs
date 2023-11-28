using BlackECS.Components;
using UnityEngine;

public class CubeInitializationComponent : IComponent
{
    public ComponentDataField<Vector3> position;
    public ComponentDataField<Cube> view;
    public ComponentDataField<Material> color;
}
