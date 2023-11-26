using LasyDI.Pool;
using System.Collections.Generic;
using UnityEngine;

public class PoolCubes<T> : BasePoolObjectDI<Cube>
    where T : MonoBehaviour
{
    public virtual void OnSpawn(T element)
    {
        element.gameObject.SetActive(true);
    }

    public virtual void OnDespawn(T element)
    {
        element.gameObject.SetActive(false);
    }
}