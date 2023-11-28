using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using LasyDI;
using BlackECS;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _force;

    private PoolBullet<Bullet> _pool;

    public Transform ShootPoint => _shootPoint;
    public float Force => _force;
    public PoolBullet<Bullet> BulletPool => _pool;

    [Inject]
    public void Costrain() { }

    private void Start()
    {
        World.CreateEntity().AddComponent<GunInputComponent>();
        _pool = LasyContainer.GetObject<PoolBullet<Bullet>>();
    }
}
