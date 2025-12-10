using Microsoft.ML;
using System;
using System.IO;

namespace RecomShop.ML
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            // Path dataset
            var dataPath = Path.Combine(AppContext.BaseDirectory, "dataset.csv");

            if (!File.Exists(dataPath))
                throw new FileNotFoundException($"dataset.csv nu a fost găsit! Calea: {dataPath}");

            Console.WriteLine("Încarc datasetul...");

            var data = mlContext.Data.LoadFromTextFile<ProductData>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            // Pipeline corect
            var pipeline = mlContext.Transforms.CopyColumns(
                                outputColumnName: "Label",
                                inputColumnName: nameof(ProductData.Price))
                           .Append(mlContext.Transforms.Concatenate(
                                "Features", nameof(ProductData.Rating)))
                           .Append(mlContext.Regression.Trainers.Sdca());

            Console.WriteLine("Antrenez modelul...");

            var model = pipeline.Fit(data);

            // Save model
            var modelPath = Path.Combine(AppContext.BaseDirectory, "model.zip");
            mlContext.Model.Save(model, data.Schema, modelPath);

            Console.WriteLine($"Model salvat la: {modelPath}");
            Console.WriteLine("Totul a funcționat!");
            Console.ReadLine();
        }
    }
}
