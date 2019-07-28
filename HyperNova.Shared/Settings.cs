using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HyperNova.Shared
{
    public static class Settings
    {
        private static readonly string ProgramDirectory = Directory.GetCurrentDirectory();

        public static class GMHyperLocation
        {
            public static string Load()
            {
                string json = File.ReadAllText($"{ProgramDirectory}\\gmhyper.json");

                return JsonConvert.DeserializeObject<string>(json);
            }
            public static void Save(string location)
            {
                string json = JsonConvert.SerializeObject(location);

                File.WriteAllText($"{ProgramDirectory}\\gmhyper.json", json);
            }
        }

        public static class Templates
        {
            public static List<Template> Load()
            {
                string json = File.ReadAllText($"{ProgramDirectory}\\templates.json");

                return JsonConvert.DeserializeObject<List<Template>>(json);
            }

            public static void Save(List<Template> templates)
            {
                string json = JsonConvert.SerializeObject(templates);

                File.WriteAllText($"{ProgramDirectory}\\templates.json", json);
            }
        }
    }
    public class Template
    {
        public string Name { get; set; }
        public string ProjectLocation { get; set; }
        public string CacheLocation { get; set; }

        public Template(string name, string projectLocation, string cacheLocation)
        {
            Name = name;
            ProjectLocation = projectLocation;
            CacheLocation = cacheLocation;
        }
    }
}
