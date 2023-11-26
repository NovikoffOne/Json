using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackECS;
using BlackECS.Systems;
using UnityEngine;

public class CubeWaitTakeAttackSystem : BaseSystem<CubeWaitTakeAttackComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeWaitTakeAttackComponent component, float deltaTime)
    {
        var scaleFactor = UnityEngine.Random.Range(0.8f, 2f);
        var speed = UnityEngine.Random.Range(0.5f, 4);
        var randomDirection = (Vector3.right + Vector3.up) * UnityEngine.Random.Range(0f, 10);

        if (Input.GetKeyDown(KeyCode.A))
        {
            this.TransitToComponent<CubeTakeAttackComponent>(x =>
            {
                x.view.Value = component.view.Value;
                x.scaleForce.Value = scaleFactor;
                x.speed.Value = speed;
                x.direction.Value = randomDirection;
            });
        }
    }
}