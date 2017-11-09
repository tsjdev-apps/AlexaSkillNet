using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaSkillNet.Services
{
    public static class HttpService
    {
        /// <summary>
        /// Makes an get webrequest to a webe endpoint and returns the deserialized object.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="url">The url.</param>
        /// <returns>Result of type TClass</returns>
        public static async Task<TClass> GetRequestAsync<TClass>(string url)
            where TClass : class
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<TClass>(responseString);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"HttpService | GetRequestAsync | {ex.Message}");
                }
            }

            return default(TClass);
        }
    }
}
