using LasyDI.Pool;
using UnityEngine;

public class PoolCubes<T> : BasePoolObjectDI<Cube>
    where T : MonoBehaviour
{
    private float baseScale = 0.5f;

    public override void OnSpawn(Cube currentObject)
    {
        currentObject.transform.localScale = new Vector3(baseScale, baseScale, 1);

        currentObject.gameObject.SetActive(true);
    }

    public override void OnDespawn(Cube currentObject)
    {
        currentObject.transform.localScale = new Vector3(baseScale, baseScale, 1);

        currentObject.gameObject.SetActive(false);
    }
}