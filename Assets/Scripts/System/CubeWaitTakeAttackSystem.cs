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
        var scaleFactor = UnityEngine.Random.Range(0.3f, 1f);
        var speed = UnityEngine.Random.Range(0.5f, 4);
        var randomDirection = (Vector3.up + Vector3.right) * UnityEngine.Random.Range(-5f, 5);
        var lifeTime = UnityEngine.Random.Range(1, 3);

        if (Input.GetKeyDown(KeyCode.A))
        {
            this.TransitToComponent<CubeTakeAttackComponent>(x =>
            {
                x.view.Value = component.view.Value;
                x.scaleForce.Value = scaleFactor;
                x.speed.Value = speed;
                x.direction.Value = randomDirection;
                x.lifeTime.Value = lifeTime;
            });
        }
    }
}