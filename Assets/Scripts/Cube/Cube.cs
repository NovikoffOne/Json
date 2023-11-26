using UnityEngine;
using LasyDI;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _transform;

    public Renderer Renderer => _renderer;
    public Transform Transform => _transform;

    [Inject]
    public void Constract()
    {

    }
}