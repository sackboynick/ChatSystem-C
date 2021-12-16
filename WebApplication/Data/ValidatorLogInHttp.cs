using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.User;
using Entities;

namespace WebApplication.Data
{
    public class ValidatorLogInHttp: IUserService
    {
        public async Task<User> ValidateUser(string userName, string password)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            
            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/LogIn/"+userName+"/"+password).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return user;
        }

        public async Task<Task> RegisterUser(User user)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using HttpClient client = new HttpClient(clientHandler);
            
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
            string userAsJson = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                userAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:5001/LogIn", content).ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            return Task.CompletedTask;
        }
    }
}