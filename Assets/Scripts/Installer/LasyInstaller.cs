using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LasyDI;

public class LasyInstaller : MonoInstaller
{
    [SerializeField] public Cube _cubePrefab;

    public override void OnInstall()
    {
        LasyContainer
            .Bind<LasyTest>()
            .AsSingle();

        LasyContainer
            .Bind<LasyTest2>()
            .AsSingle();

        LasyContainer
            .BindPool<PoolCubes<Cube>, Cube>()
            .WhereInstance(_cubePrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LasyContainer.GetObject<LasyTest>().Execute();
        }
    }
}
