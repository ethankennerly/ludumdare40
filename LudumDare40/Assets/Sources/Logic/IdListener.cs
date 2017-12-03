using System;
using Entitas;

public sealed class IdListener
{
    // Copied from:
    // https://github.com/sschmid/Entitas-CSharp/wiki/FAQ#q-should-i-store-references-to-entities-inside-components
    public static void ReplaceIds(bool isListening)
    {
        Contexts contexts = Contexts.sharedInstance;
        foreach (var context in contexts.allContexts)
        {
            Type[] types = context.contextInfo.componentTypes;
            if (Array.IndexOf(types, typeof(IdComponent)) < 0)
            {
                continue;
            }
            if (isListening)
            {
                context.OnEntityCreated += ReplaceId;
            }
            else
            {
                context.OnEntityCreated -= ReplaceId;
            }
        }
    }

    private static void ReplaceId(IContext context, IEntity entity)
    {
        IId idEntity = (IId)entity;
        idEntity.ReplaceId(entity.creationIndex);
    }
}
