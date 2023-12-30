using CRMS.Blazor.Data.DTO;
using Newtonsoft.Json;

namespace CRMS.Blazor.Data.Services
{
    public class StaffService
    {
        private readonly HttpClient _httpClient;
        private string baseUrl = "https://localhost:44397/";
        public StaffService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StaffData>?> GetStaffAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:44397/api/staff/all-staff");

            var result = response.Content.ReadAsStringAsync().Result;
            var rr = JsonConvert.DeserializeObject<List<StaffData>>(result);
            return rr;
        }
    }
}
