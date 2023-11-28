using BlackECS;
using BlackECS.Systems;
using LasyDI;
using UnityEngine;

public class CubeTakeAttackSystem : BaseSystem<CubeTakeAttackComponent>
{
    private float _minScaleFactor = 0.009f;
    private float _minScale = 0.001f;
    private float _maxScale = 2f;

    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(CubeTakeAttackComponent component, float deltaTime)
    {
        component.timer.Value += deltaTime;

        if (component.timer.Value >= component.lifeTime.Value)
        {
            LasyContainer.GetObject<PoolCubes<Cube>>().Despawn(component.view.Value);

            this.DestroyEntity();

            return;
        }

        component.view.Value.transform.Translate(component.direction.Value * component.speed.Value * Time.deltaTime);

        if (TryScaleValue(component.view.Value.transform.localScale))
        {
            component.view.Value.transform.localScale = new Vector3(
                ClampValue(component.view.Value.transform.localScale.x - component.scaleForce.Value * deltaTime),
                ClampValue(component.view.Value.transform.localScale.y - component.scaleForce.Value * deltaTime),
                ClampValue(component.view.Value.transform.localScale.z - component.scaleForce.Value * deltaTime));
        }
    }

    private bool TryScaleValue(Vector3 temp)
    {
        if (temp.x >= _minScaleFactor && temp.y >= _minScaleFactor && temp.z >= _minScaleFactor)
        {
            return true;
        }

        return false;
    }

    private float ClampValue(float value)
    {
        return Mathf.Clamp(value, _minScale, _maxScale);
    }
}