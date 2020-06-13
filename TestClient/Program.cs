using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            var prevResponse = String.Empty;

            while (true)
            {
                var response = await client.GetStringAsync("http://localhost:5010/settings");
                
                if (response != prevResponse)
                {
                    Console.WriteLine(response);
                    prevResponse = response;
                }
            }
        }
    }
}