using BlackECS;
using BlackECS.Systems;
using LasyDI;
using UnityEngine;

public class CubeTakeAttackSystem : BaseSystem<CubeTakeAttackComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeTakeAttackComponent component, float deltaTime)
    {
        component.view.Value.transform.Translate(component.direction.Value * component.speed.Value * Time.deltaTime);

        if (TryScaleValue(component.view.Value.transform.localScale))
        {
            component.view.Value.transform.localScale = new Vector3(
                ClampValue(component.view.Value.transform.localScale.x - component.scaleForce.Value * deltaTime),
                ClampValue(component.view.Value.transform.localScale.y - component.scaleForce.Value * deltaTime),
                ClampValue(component.view.Value.transform.localScale.z - component.scaleForce.Value * deltaTime));
        }

        component.timer.Value += deltaTime;

        if (component.timer.Value >= component.lifeTime.Value)
        {
            LasyContainer.GetObject<PoolCubes<Cube>>().Despawn(component.view.Value);
            
            this.DestroyEntity();
        }
    }

    private bool TryScaleValue(Vector3 temp)
    {
        if (temp.x >= 0.009 && temp.y >= 0.009 && temp.z >= 0.009)
        {
            return true;
        }
     
        return false;
    }

    private float ClampValue(float value)
    {
        return Mathf.Clamp(value, 0.001f, 2);
    }
}