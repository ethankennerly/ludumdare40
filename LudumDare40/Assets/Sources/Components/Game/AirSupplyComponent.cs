using System;
using Entitas;
using UnityEngine;
using Finegamedesign.Utils;

[Serializable]
[Game]
public sealed class AirSupplyComponent : IComponent
{
    public Timer timer;
    public float initialTime;
}
