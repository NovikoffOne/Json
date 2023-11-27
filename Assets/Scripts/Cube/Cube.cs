using UnityEngine;
using LasyDI;
using Unity.VisualScripting;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _transform;
    
    private bool _hit = false;

    public Renderer Renderer => _renderer;
    public Transform Transform => _transform;
    public bool Hit => _hit;

    [Inject]
    public void Constract()
    {

    }

    private void OnDisable()
    {
        _hit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _hit = true;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}