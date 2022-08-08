using System.Net.Http.Headers;

namespace Jifiti.API
{
    public class TransctionsService : ITransactionsService
    {
        private readonly HttpClient client;
        private readonly IConfiguration _configuration;

        //Dependecy Injection - Here i'm using clientFactory,
        //so that I can use a specific HTTP Client object
        public TransctionsService(IHttpClientFactory clientFactory)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            client = clientFactory.CreateClient("TransactionsApi");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _configuration.GetValue<string>("Headers:Authroization"));


        }
        public async Task<string> GetPersons()
        {
            var url = "applications";
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

        public async Task<string> GetCards(string appId)
        {
            var url = string.Format("cards/{0}", appId);
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

        public async Task<string> GetTransactions(string appId)
        {
            var url = string.Format("trans/{0}", appId);
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
