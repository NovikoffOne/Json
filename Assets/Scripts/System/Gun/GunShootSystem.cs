using BlackECS;
using BlackECS.Systems;
using UnityEngine;

public class GunShootSystem : BaseSystem<GunShootComponent>
{
    private float _forceFactor = 100f;

    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(GunShootComponent component, float deltaTime)
    {
        var bullet = component.Gun.BulletPool.Spawn();

        bullet.transform.position = component.Gun.ShootPoint.position;

        var direction = CalculateDiraction(component.Gun.Force);

        bullet.Rigidbody.AddForce(direction * Time.deltaTime, ForceMode.Impulse);

        this.TransitToComponent<GunInputComponent>();
    }

    private Vector3 CalculateDiraction(float force)
    {
        var targetPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        targetPosition *= force * _forceFactor;

        return targetPosition;
    }
}
