using BlackECS;
using BlackECS.Systems;
using System;
using UnityEngine;

public class CubeInitializationSystem : BaseSystem<CubeInitializationComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeInitializationComponent component, float deltaTime)
    {
        component.transform.Value.position = component.position.Value;

        component.renderer.Value.material
            .SetColor("_Color", component.colors[component.colorIndex.Value]);

        this.TransitToComponent<CubeWaitTakeAttackComponent>(x =>
        {
            x.Transform.Value = component.transform.Value;
            x.pool = component.pool;
        });

        this.ForgetComponent<CubeInitializationComponent>();
    }
}
