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
        auditEntity.ReplaceAudit(new List<string>());
        ((Entity)auditEntity).OnEntityRetained += AppendLog;
    }

    private static void AppendLog(IEntity entity, object owner)
    {
        IAuditEntity auditEntity = (IAuditEntity)entity;
        if (auditEntity == null)
        {
             return;
        }
        List<string> logs;
        if (auditEntity.hasAudit)
        {
            logs = auditEntity.audit.logs;
        }
        else
        {
            logs = new List<string>();
        }
        logs.Add(owner.ToString());
        auditEntity.ReplaceAudit(logs);
    }
#endif
}
