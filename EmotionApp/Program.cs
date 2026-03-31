using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.ML;

namespace EmotionApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Check if the app is running inside a Docker container
            bool isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

            if (isDocker)
            {
                RunConsoleMode();
            }
            else
            {
                RunUiMode();
            }
        }

        /// <summary>
        /// This runs on your local machine with the full visual interface.
        /// </summary>
        private static void RunUiMode()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// This runs inside the Linux Docker container where no UI is available.
        /// </summary>
        private static void RunConsoleMode()
        {
            Console.WriteLine("=== Emotion App AI Analysis (Docker Mode) ===");

            // Define paths for Docker environment
            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "emotions.txt");
            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "emotion_model.zip");

            // 2. Check if the model needs training using YOUR existing method!
            if (!File.Exists(modelPath))
            {
                Console.WriteLine("Model not found. Triggering training first...");

                if (File.Exists(dataPath))
                {
                    // Calling YOUR existing function here
                    ModelTrainer.TrainModel(dataPath, modelPath);
                }
                else
                {
                    Console.WriteLine($"Error: Training data file not found at {dataPath}");
                    return;
                }
            }

            // 3. Make the prediction directly here in Program.cs
            string textToAnalyze = "I am so incredibly happy that this Docker container is finally working!";
            Console.WriteLine($"\nAnalyzing text: \"{textToAnalyze}\"");

            try
            {
                var mlContext = new MLContext();

                // Load the model that your trainer just created
                ITransformer loadedModel = mlContext.Model.Load(modelPath, out var modelInputSchema);

                // Create prediction engine
                var predictionEngine = mlContext.Model.CreatePredictionEngine<EmotionData, EmotionPrediction>(loadedModel);

                // Predict
                var sampleData = new EmotionData { Text = textToAnalyze };
                var prediction = predictionEngine.Predict(sampleData);

                Console.WriteLine("\n🎯 Analysis Results:");
                Console.WriteLine($"Emotion: {prediction.Emotion}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error analyzing text: {ex.Message}");
            }
        }
    }
}