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
}
