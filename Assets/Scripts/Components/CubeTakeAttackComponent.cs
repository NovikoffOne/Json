using System;
using System.Collections.Generic;
using BlackECS.Components;
using UnityEngine;

public class CubeTakeAttackComponent : IComponent
{
    public ComponentDataField<Vector3> Direction;
    public ComponentDataField<Transform> Transform;
    public ComponentDataField<float> scaleForce;
    public ComponentDataField<float> speed;
    public ComponentDataField<float> Timer;
}
