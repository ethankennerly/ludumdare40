using System;
using Entitas;
using UnityEngine;

[Serializable]
[Game]
public sealed class DrivableBodyComponent : IComponent
{
    public Rigidbody2D body;
    public bool horizontalEnabled;
    public bool verticalEnabled;
    public Vector2 force = new Vector2(1.0f, 1.0f);
}
