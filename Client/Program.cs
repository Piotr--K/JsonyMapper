using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62718/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/people");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Person> people = await response.Content.ReadAsAsync<IEnumerable<Person>>();
                    foreach (var person in people)
                    {
                        Console.WriteLine("{0} {1}, age:{2}", person.FirstName, person.LastName, person.Age);
                    }
                    
                }
            }
        }
    }

    public class Person
    {
        [JsonProperty(PropertyName = "first_Name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_Name")]
        public string LastName { get; set; }
        public string Age { get; set; }
    }
}
