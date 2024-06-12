using Models;
using Newtonsoft.Json;
using System.Text;

namespace ProjAndreVeiculosSummary.Services
{
    public class BankService
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Bank> PostBank(Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await BankService.client.PostAsync("https://localhost:7228/api/Bank", content);
                response.EnsureSuccessStatusCode();
                string bankReturn = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<Bank>(bankReturn);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
