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

            // Set up the HTTP client
            using (HttpClient client = new HttpClient())
            {
                // Set the request URI
                var requestUri = new Uri("https://rapidapi.com");


                // Add headers
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "b2455b5750msh63c73af28d897d5p16a91djsn67e64142420c");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "travel-advisor.p.rapidapi.com");

                try
                {
                    // Send the GET request and get the response
                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response body
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response from RapidAPI:");
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        // Print an error message if the request was not successful
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during the request
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Keep the console window open
            Console.ReadLine();
        }
    }
}
