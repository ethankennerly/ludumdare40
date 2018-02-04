using System;
using Entitas;

public sealed class OnEntityCreated
{
    // Copied from:
    // https://github.com/sschmid/Entitas-CSharp/wiki/FAQ#q-should-i-store-references-to-entities-inside-components
    public static void Subscribe(Type componentType, ContextEntityChanged onEntityCreated, bool isSubscribing)
    {
        Contexts contexts = Contexts.sharedInstance;
        foreach (var context in contexts.allContexts)
        {
            Type[] types = context.contextInfo.componentTypes;
            if (Array.IndexOf(types, componentType) < 0)
            {
                continue;
            }
            if (isSubscribing)
            {
                context.OnEntityCreated += onEntityCreated;
            }
            else
            {
                context.OnEntityCreated -= onEntityCreated;
            }
        }
    }
}
