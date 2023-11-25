using BlackECS;
using BlackECS.Systems;
using System;
using UnityEngine;

public class CubeInitializationSystem : BaseSystem<CubeInitializationComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeInitializationComponent component, float deltaTime)
    {
        component.Transform.Value.position = component.Position.Value;

        component.Renderer.Value.material.SetColor("_Color", component.Color[component.ColorIndex.Value]);

        this.TransitToComponent<CubeWaitTakeAttackComponent>(x =>
        {
            x.Transform.Value = component.Transform.Value;
        });

        this.ForgetComponent<CubeInitializationComponent>();
    }
}
