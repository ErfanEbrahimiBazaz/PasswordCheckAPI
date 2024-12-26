using PasswordCheck.API.Models;
using System;
using System.Runtime.CompilerServices;

namespace PasswordCheck.API.Services
{
    public interface IPasswordBreachCheckService
    {
        public Task<PasswordBreachResponse> CheckBreach(PasswordRequest password);

    }

    public class PasswordBreachCheckService : IPasswordBreachCheckService
    {
        // send Get request to the pwnd endpoint and returns how many times a password is breached.
        private readonly HttpClient _httpClient;
        private readonly string _hibpEndpoint = string.Empty;

        public PasswordBreachCheckService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _hibpEndpoint = configuration["hibpEndpoint"] ?? throw new ArgumentNullException("hibpEndpoint is not configuredd in appSettings.json");
        }
        public async Task<PasswordBreachResponse> CheckBreach(PasswordRequest password)
        {

            
            string range = PasswordOperations.CalculateSHA1Hash(password.Password);

            //string url = $"https://api.pwnedpasswords.com/range/{range}";
            string url =  $"{_hibpEndpoint}{range}";

            //PasswordBreachResponse passwordBreachResponse = new PasswordBreachResponse();

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();


            var totalCount = content
                .Split('\n')
                .Select(x => x.ToString().Split(':'))
                .ToDictionary(x => x[0], x => int.Parse(x[1]))
                .Sum(x => x.Value);

            //passwordBreachResponse.NumberOfBreaches = totalCount;

            //return Content(content);
            //return passwordBreachResponse;                //return passwordBreachResponse;
            return new PasswordBreachResponse
            {
                NumberOfBreaches = totalCount
            };

        }
    }
}
