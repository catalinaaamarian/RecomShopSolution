using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using System.IO;
using RecomShop.ML;
using System;


namespace RecomShop.ML.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLController : ControllerBase
    {
        private static readonly MLContext mlContext = new MLContext();
        private static readonly ITransformer model;
        private static readonly PredictionEngine<ProductData, ProductPrediction> predictionEngine;

        // *** Constructor STATIC (îl lași exact așa!) ***
        static MLController()
        {
            string baseDir = AppContext.BaseDirectory;
            string modelPath = Path.Combine(baseDir, "model.zip");

            Console.WriteLine("=== DEBUG ML API ===");
            Console.WriteLine($"Calea API: {baseDir}");
            Console.WriteLine($"Model găsit: {System.IO.File.Exists(modelPath)}");

            Console.WriteLine("====================");

            if (!System.IO.File.Exists(modelPath))

            {
                throw new FileNotFoundException(
                    $"Eroare: model.zip nu există în {baseDir}. Copiază model.zip în folderul API!",
                    modelPath);
            }

            model = mlContext.Model.Load(modelPath, out _);
            predictionEngine = mlContext.Model.CreatePredictionEngine<ProductData, ProductPrediction>(model);
        }

        [HttpGet("predict")]
        public IActionResult PredictPrice(float rating)
        {
            if (rating < 1 || rating > 5)
                return BadRequest("Ratingul trebuie să fie între 1 și 5.");

            var input = new ProductData { Rating = rating };
            var prediction = predictionEngine.Predict(input);

            return Ok(new
            {
                Rating = rating,
                PredictedPrice = prediction.PredictedPrice
            });
        }
    }
}
