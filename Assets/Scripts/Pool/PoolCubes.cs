using LasyDI.Pool;
using System.Collections.Generic;
using UnityEngine;

public class PoolCubes<T> : BasePoolObjectDI<Cube>
    where T : MonoBehaviour
{
    private readonly T Prefab;
    //private readonly Transform PoolContainer;

    //private List<T> _pool;

    //public readonly List<T> Pool;

    public PoolCubes(T prefab)
    {
        //Prefab = prefab;
        //_pool = new List<T>();

        //PoolContainer = new GameObject().transform;

        //Object.DontDestroyOnLoad(PoolContainer);
    }

    //public int Count => _pool.Count;

    public virtual void OnSpawn(T element)
    {
        element.gameObject.SetActive(true);
    }

    public virtual void OnDespawn(T element)
    {
        element.gameObject.SetActive(false);
    }

    //public void DeSpawnAll()
    //{
    //    _pool.ForEach(element => OnDespawn(element));
    //}
}