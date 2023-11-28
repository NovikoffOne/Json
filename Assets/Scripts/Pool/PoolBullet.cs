using LasyDI.Pool;
using UnityEngine;

public class PoolBullet<T> : BasePoolObjectDI<Bullet>
    where T : MonoBehaviour
{
    public override void OnSpawn(Bullet currentObject)
    {
        currentObject.gameObject.SetActive(true);
    }

    public override void OnDespawn(Bullet currentObject)
    {
        currentObject.gameObject.SetActive(false);
    }
}
