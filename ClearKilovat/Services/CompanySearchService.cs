using ClearKilovat.Interfaces;
using ClearKilovat.Models.Entity;
using ClearKilovat.Models.Parser;
using Newtonsoft.Json.Linq;


namespace ClearKilovat.Services
{
    public class CompanySearchService : ICompanySearchService
    {
        private readonly HttpClient _client;
        private readonly string apiKey = Environment.GetEnvironmentVariable("TWO_GIS_API_KEY") ?? throw new ArgumentNullException(nameof(apiKey));
        private readonly List<string> _commercialKeywords = new List<string>
        {
            "Магазин", "Офис", "Торговый центр", "Бизнес-центр", "Коммерческое помещение",
            "Склад", "Ресторан", "Кафе", "Салон", "Отель", "Маникюр",
            "Административное здание", "Производственный корпус", "Автомойка",
            "Гостиница", "Объект", "Хозяйственный корпус", "Сооружение","Коттедж"
        };

        public CompanySearchService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IdPurposeDTO> GetBuildingId(string address)
        {
            var encodedAddress = Uri.EscapeDataString(address);
            var url = $"https://catalog.api.2gis.com/3.0/items?q={encodedAddress}&type=building&key={apiKey}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);

            var item = jObject["result"]?["items"]?[0];
            var fullName = item?["full_name"]?.ToString();
            var id = item?["id"]?.ToString();
            var purposeName = item?["purpose_name"]?.ToString() ?? string.Empty;

            if (fullName?.ToLower().Contains("гостевой") == true)
            {
                purposeName = "Гостевой дом";
            }
            IdPurposeDTO result = new()
            {
                Id = id?.Split('_')[0] ?? string.Empty,
                PurposeName = purposeName ?? string.Empty
            };

            return result;
        }

        public async Task<List<Company>> GetCompaniesInBuilding(string buildingId)
        {
            var url = $"https://catalog.api.2gis.com/3.0/items?building_id={buildingId}&key={apiKey}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);

            var companiesList = new List<Company>();

            foreach (var item in jObject["result"]?["items"] ?? new JArray())
            {
                companiesList.Add(new Company
                {
                    Name = item["name"]?.ToString() ?? "Без названия",
                    Adress = item["address_name"]?.ToString() ?? string.Empty,
                    PhoneNumber = GeneratePhoneNumber()
                });
            }

            return companiesList;
        }

        public static string GeneratePhoneNumber()
        {
            string[] operators = { "918", "928", "938", "961", "962" };
            Random random = new Random();
            string operatorCode = operators[random.Next(operators.Length)];
            return $"+7{operatorCode}{random.Next(1000000, 9999999)}";
        }


        public bool IsCommercialBuilding(string purposeName)
        {
            return _commercialKeywords.Any(keyword => purposeName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
