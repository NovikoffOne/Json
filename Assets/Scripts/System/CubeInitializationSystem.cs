using BlackECS;
using BlackECS.Systems;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class CubeInitializationSystem : BaseSystem<CubeInitializationComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeInitializationComponent component, float deltaTime)
    {
        component.view.Value.transform.position = component.position.Value;

        //component.view.Value.Renderer.material
        //    .SetColor("_Color", component.color.Value);

        var material = new Material(component.view.Value.GetComponent<Renderer>().sharedMaterial);

        material.color = component.color.Value;

        component.view.Value.Renderer.material = material;

        this.TransitToComponent<CubeWaitTakeAttackComponent>(x =>
        {
            x.view.Value = component.view.Value;
            x.pool = component.Pool;
        });
    }
}
