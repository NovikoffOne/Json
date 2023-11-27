using BlackECS;
using LasyDI;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Material _material;

    private void Start()
    {
        var cubeData = new JsonToString().WriteJsonFile();
        var data = cubeData._data;

        var pool = LasyContainer.GetObject<PoolCubes<Cube>>();

        var colors = CreateColorsPalette(cubeData._colors);

        for (int i = 0; i < data.Count; i++)
        {
            var cube = pool.Spawn();

            World
            .CreateEntity()
            .AddComponent<CubeInitializationComponent>(x =>
            {
                x.view.Value = cube;
                x.position.Value = data[i].position;
                x.color.Value = colors[cubeData._colors[data[i].colorIndex]];
            });
        }
    }

    private Dictionary<Color, Material> CreateColorsPalette(List<Color> dataColors)
    {
        var colors = new Dictionary<Color, Material>();

        foreach (var color in dataColors)
        {
            if (colors.ContainsKey(color) == false)
            {
                var tempMaterial = new Material(_material);
                tempMaterial.color = color;

                colors[color] = tempMaterial;
            }
        }

        return colors;
    }
}
