using Entitas;
using System;
using System.Collections.Generic;

public sealed class ReplaceOnCreated
{
    public static void Subscribe(bool isSubscribing)
    {
        OnEntityCreated.Subscribe(typeof(IdComponent), ReplaceId, isSubscribing);
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        OnEntityCreated.Subscribe(typeof(AuditComponent), AuditOnRetained, isSubscribing);
#endif
    }

    private static void ReplaceId(IContext context, IEntity entity)
    {
        IIdEntity idEntity = (IIdEntity)entity;
        idEntity.ReplaceId(entity.creationIndex);
    }

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
    // To unsubscribe from `AppendLog`, query each entity and unsubscribe.
    private static void AuditOnRetained(IContext context, IEntity entity)
    {
        IAuditEntity auditEntity = (IAuditEntity)entity;
        ((Entity)auditEntity).OnEntityRetained += AppendLog;
    }

    // Does not append log if entity has no audit.
    // This prevents spam of entities that get retained every frame.
    // To enable log, add an audit component to the entity.
    // Likewise, to disable log, remove an audit component from the entity.
    // In visual debugging, there is a drop-down to add components.
    private static void AppendLog(IEntity entity, object owner)
    {
        IAuditEntity auditEntity = (IAuditEntity)entity;
        if (auditEntity == null)
        {
             return;
        }
        if (!auditEntity.hasAudit)
        {
            return;
        }
        List<string> logs = auditEntity.audit.logs;
        if (logs == null)
        {
            logs = new List<string>();
        }
        logs.Add(owner.ToString());
        auditEntity.ReplaceAudit(logs);
    }
#endif
}
