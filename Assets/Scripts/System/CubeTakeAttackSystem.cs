using BlackECS;
using BlackECS.Systems;
using LasyDI;
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
        var currentLifeTime = UnityEngine.Random.Range(2, 5);

        component.transform.Value.Translate(component.direction.Value * component.speed.Value * Time.deltaTime);

        component.transform.Value.localScale -= Vector3.one * component.scaleForce.Value * deltaTime;

        if (TryScaleValue(component.transform.Value.localScale))
        {
            component.pool.Despawn(component.transform.Value
                .GetComponent<Cube>());
            
            this.DestroyEntity();
        }

        component.timer.Value += deltaTime;

        if (component.timer.Value >= currentLifeTime)
        {
            component.pool.Despawn(component.transform.Value
                .GetComponent<Cube>());

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