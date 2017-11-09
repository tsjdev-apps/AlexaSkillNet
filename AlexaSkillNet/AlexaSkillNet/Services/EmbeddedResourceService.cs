using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace AlexaSkillNet.Services
{
    public static class EmbeddedResourceService
    {
        public static TClass GetData<TClass>(string resourcePath)
            where TClass : class
        {
            try
            {
                var assembly = typeof(EmbeddedResourceService).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream(resourcePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TClass>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EmbeddedResourceService | GetData | {ex.Message}");
            }

            return default(TClass);
        }
    }
}
