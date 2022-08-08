using System.Net.Http.Headers;

namespace Jifiti.API
{
    public class TransctionsService : ITransactionsService
    {
        private static readonly HttpClient client;
        private static readonly IConfiguration _configuration;
        static TransctionsService()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            client = new HttpClient()
            {
               BaseAddress = new Uri("https://rpnszaidmg.execute-api.eu-west-1.amazonaws.com/Prod/")
            };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _configuration.GetValue<string>("Headers:Authroization"));


        }

        public async Task<string> GetPersons()
        {       
            var url = string.Format("applications");
            string? stringResponse;
            using (var response = await client.GetAsync(url))
            {         
                if (response.IsSuccessStatusCode)
                {
                    stringResponse = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
               
            return stringResponse;
        }
    }
}
