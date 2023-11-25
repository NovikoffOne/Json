using BlackECS;
using BlackECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CubeTakeAttackSystem : BaseSystem<CubeTakeAttackComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeTakeAttackComponent component, float deltaTime)
    {
        var currentTime = UnityEngine.Random.Range(2, 5);

        component.Transform.Value.Translate(component.Direction.Value * component.speed.Value * Time.deltaTime);

        component.Transform.Value.localScale -= Vector3.one * component.scaleForce.Value * deltaTime;

        if (TryScaleValue(component.Transform.Value.localScale))
        {
            GameObject.Destroy(component.Transform.Value.gameObject);
            this.DestroyEntity();
        }

        component.Timer.Value += deltaTime;

        if (component.Timer.Value >= currentTime)
        {
            GameObject.Destroy(component.Transform.Value.gameObject);
            this.DestroyEntity();
        }
    }

    private bool TryScaleValue(Vector3 temp)
    {
        if (temp.x <= 0 || temp.y <= 0 || temp.z <= 0)
        {
            return true;
        }
        else 
            return false;
    }
}