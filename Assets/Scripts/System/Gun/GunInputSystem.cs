using BlackECS;
using BlackECS.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInputSystem : BaseSystem<GunInputComponent>
{
    public override int SystemUpdateOrder => 0;

    public override void OnUpdate(GunInputComponent component, float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.TransitToComponent<GunShootComponent>();
        }
    }
}
