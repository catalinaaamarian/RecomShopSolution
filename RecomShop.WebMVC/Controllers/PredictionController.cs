using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace RecomShop.WebMVC.Controllers
{
    public class PredictionController : Controller
    {
        private readonly HttpClient _http;

        public PredictionController(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Predict(float rating)
        {
            var url = $"https://localhost:7038/api/ML/predict?rating={rating}";

            var response = await _http.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PredictionResponse>(json);

            return View("Index", result);
        }
    }

    public class PredictionResponse
    {
        public float Rating { get; set; }
        public float PredictedPrice { get; set; }
    }
}
