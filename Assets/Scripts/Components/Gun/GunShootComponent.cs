using BlackECS.Components;

public class GunShootComponent : IComponent
{
    public GunShootComponent(Gun gun)
    {
        Gun = gun;
    }

    public Gun Gun { get; }
}
