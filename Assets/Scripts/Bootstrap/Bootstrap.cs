using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BlackECS;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Cube _cubesPrefabs;

    PoolCubes<Cube> _pool;

    private void Start()
    {
        _pool = new PoolCubes<Cube>(_cubesPrefabs);

        World.RegistrationSystem<CubeInitializationSystem>();
        World.RegistrationSystem<CubeWaitTakeAttackSystem>();
        World.RegistrationSystem<CubeTakeAttackSystem>();

        var cubeData = new JsonToString().WriteJsonFile();
        var data = cubeData._data;

        for (int i = 0; i < data.Count; i++)
        {
            var cube = _pool.Spawn();

            World
            .CreateEntity()
            .AddComponent<CubeInitializationComponent>(x =>
            {
                x.transform.Value = cube.transform;
                x.renderer.Value = cube.Renderer;
                x.position.Value = data[i].position;
                x.colorIndex.Value = data[i].colorIndex;

                x.pool = _pool;
                x.colors = cubeData._colors;
            });
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            int layerMask = 1 << 8;

            layerMask = ~layerMask;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
                Debug.Log(hit.collider.gameObject.name);
        }
    }
}
