using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BlackECS;
using LasyDI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Cube _cubesPrefabs;

    private void Start()
    {
        var cubeData = new JsonToString().WriteJsonFile();
        var data = cubeData._data;

        var pool = LasyContainer.GetObject<PoolCubes<Cube>>();

        Dictionary<int, Color> colors = new Dictionary<int, Color>();

        for (int i = 0; i < cubeData._colors.Count; i++)
        {
            colors[i] = cubeData._colors[i];
        }

        for (int i = 0; i < data.Count; i++)
        {
            var cube = pool.Spawn();

            World
            .CreateEntity()
            .AddComponent<CubeInitializationComponent>(x =>
            {
                x.view.Value = cube;
                x.position.Value = data[i].position;
                x.color.Value = colors[data[i].colorIndex];
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
