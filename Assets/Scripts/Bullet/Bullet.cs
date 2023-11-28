using BlackECS;
using LasyDI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    private float _lifeTime = 3f;
    private string _layerName = "Cube";

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Destroy(gameObject, _lifeTime);
    }

    [Inject]
    public void Costruct()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        var mask = LayerMask.GetMask(_layerName);
        var result = Physics.OverlapSphere(transform.position, 1f, mask);

        for (int i = 0; i < result.Length; i++)
        {
            World.CreateEntity()
                .AddComponent<CubeTakeAttackComponent>(x =>
                {
                    x.view.Value = result[i].GetComponent<Cube>();
                    x.scaleForce.Value = Random.Range(0.3f, 1f);
                    x.speed.Value = Random.Range(2, 4);
                    x.direction.Value = GetRandomVector();
                    x.lifeTime.Value = Random.Range(0.5f, 1.5f);
                });
        }
    }

    private Vector3 GetRandomVector()
    {
        var tempVector = Vector3.one;

        tempVector.x *= Random.Range(-5f, 5);
        tempVector.y *= Random.Range(-5f, 5);
        tempVector.z *= Random.Range(-5f, 5);

        return tempVector;
    }
}