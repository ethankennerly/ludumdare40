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
    public Vector2 force = new Vector2(1f, 1f);
    public float impulseMultiplier = 5f;
    public float relativeImpulseMultiplier = 1f;
    public AudioSource impulseSound;
}
