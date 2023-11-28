using LasyDI;
using UnityEngine;

public class LasyInstaller : MonoInstaller
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Gun _gun;
    [SerializeField] private Bullet _bulletPrefab;

    public override void OnInstall()
    {
        LasyContainer
            .BindPool<PoolCubes<Cube>, Cube>()
            .WhereInstance(_cubePrefab);

        LasyContainer
            .BindPool<PoolBullet<Bullet>, Bullet>()
            .WhereInstance(_bulletPrefab);

        LasyContainer
            .Bind<Gun>()
            .WhereInstance(_gun)
            .AsSingle();
    }
}
