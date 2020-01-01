using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TripLog
{
    public class AppSettingsManager
    {
        private static AppSettingsManager instance;

        private readonly JObject secrets;

        private const string Namespace = "TripLog";
        private const string Filename = "appsettings.json";

        private AppSettingsManager()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppSettingsManager)).Assembly;
            var stream = assembly.GetManifestResourceStream($"{Namespace}.{Filename}");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                secrets = JObject.Parse(json);
            }
        }

        public static AppSettingsManager Settings
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSettingsManager();
                }

                return instance;
            }
        }
        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');

                    JToken node = secrets[path[0]];
                    for (int index = 1; index < path.Length; index++)
                    {
                        node = node[path[index]];
                    }

                    return node.ToString();
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Unable to retrieve secret '{name}'");
                    return string.Empty;
                }
            }
        }
    }
}
