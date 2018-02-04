using Entitas;
using Finegamedesign.Utils;
using System;

[Serializable]
[Game]
public sealed class AirSupplyComponent : IComponent
{
    public Timer timer;
    public float initialTime;
}
