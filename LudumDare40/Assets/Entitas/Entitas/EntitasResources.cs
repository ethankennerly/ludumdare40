using System.IO;
using UnityEngine;

namespace Entitas {

    public static class EntitasResources {

        public static string GetVersion() {
            var assembly = typeof(Entity).Assembly;
            var stream = assembly.GetManifestResourceStream("version.txt");
            string version;
            if (stream == null)
            {
                string names = string.Join(", ", assembly.GetManifestResourceNames());
                Debug.LogWarning("EntitasResources.GetVersion: Did not find version.txt in resource names <" + names + ">. Defaulting to 1.0.0");
                version = "1.0.0";
            }
            else
            {
                using (var reader = new StreamReader(stream)) {
                    version = reader.ReadToEnd();
                }
            }
            return version;
        }
    }
}
