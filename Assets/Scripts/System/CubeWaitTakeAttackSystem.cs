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
        if (Input.GetKeyDown(KeyCode.A))
        {
            var scaleFactor = UnityEngine.Random.Range(0.8f, 2f);
            var speedFactor = UnityEngine.Random.Range(0.5f, 4);
            var randomDirection = (Vector3.right + Vector3.up) * UnityEngine.Random.Range(0f, 10);

            this.TransitToComponent<CubeTakeAttackComponent>(x =>
            {
                x.Transform.Value = component.Transform.Value;
                x.scaleForce.Value = scaleFactor;
                x.speed.Value = speedFactor;
                x.Direction.Value = randomDirection;
            });

            this.ForgetComponent<CubeWaitTakeAttackComponent>();
        }
    }
}
