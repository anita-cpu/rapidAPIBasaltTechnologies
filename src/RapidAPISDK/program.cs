using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RapidAPISDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize RapidAPI with your project name and API key
            RapidAPI rapidAPI = new RapidAPI("RapidAPISDK", "b2455b5750msh63c73af28d897d5p16a91djsn67e64142420c");

            // Call the Travel Advisor API
            await CallTravelAdvisorAPI();

            // Call the Currency Converter API
            await CallCurrencyConverterAPI();

            // Keep the console window open
            Console.ReadLine();
        }

        static async Task CallTravelAdvisorAPI()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/direct/?destination=LED&origin=MOW"),
                        Headers =
                        {
                            { "X-RapidAPI-Key", "b2455b5750msh63c73af28d897d5p16a91djsn67e64142420c" },
                            { "X-RapidAPI-Host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com" },
                        },
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from Travel Advisor API:");
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling Travel Advisor API: {ex.Message}");
            }
        }

        static async Task CallCurrencyConverterAPI()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://currencyconverter.p.rapidapi.com/availablecurrencies"),
                        Headers =
                        {
                            { "X-RapidAPI-Key", "b2455b5750msh63c73af28d897d5p16a91djsn67e64142420c" },
                            { "X-RapidAPI-Host", "currencyconverter.p.rapidapi.com" },
                        },
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from Currency Converter API:");
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling Currency Converter API: {ex.Message}");
            }
        }
    }
}
