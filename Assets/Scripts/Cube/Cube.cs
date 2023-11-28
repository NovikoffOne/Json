﻿using LasyDI;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public Renderer Renderer => _renderer;
    
    [Inject]
    public void Constract() { }
}