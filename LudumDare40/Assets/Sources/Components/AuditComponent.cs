using Entitas;
using System.Collections.Generic;

[Game, Input]
public sealed class AuditComponent : IComponent
{
    public List<string> logs;
}
