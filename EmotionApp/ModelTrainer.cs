using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace EmotionApp
{
    // 1. Define the structure of your Kaggle data
    public class EmotionData
    {
        // The text from the dataset
        [LoadColumn(0)]
        public string Text { get; set; }

        // The emotion label (joy, sadness, etc.)
        [LoadColumn(1)]
        public string Emotion { get; set; }
    }

    // 2. Define what the AI will predict
    public class EmotionPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Emotion { get; set; }

        public float[] Score { get; set; }
    }

    public static class ModelTrainer
    {
        public static void TrainModel(string dataPath, string modelPath)
        {
            // Initialize the ML context
            var mlContext = new MLContext(seed: 1);

            Console.WriteLine("Loading Kaggle dataset...");

            // NOTE: We use ';' as the separator because the CARER dataset uses it!
            IDataView trainingData = mlContext.Data.LoadFromTextFile<EmotionData>(
                path: dataPath,
                hasHeader: false,
                separatorChar: ';');

            Console.WriteLine("Building the training pipeline...");

            // 3. Map text to numbers and train the model
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(EmotionData.Emotion))
                .Append(mlContext.Transforms.Text.FeaturizeText("Features", nameof(EmotionData.Text)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            Console.WriteLine("Training the model (this may take a minute with a large dataset)...");
            var model = pipeline.Fit(trainingData);

            Console.WriteLine("Saving the model...");
            mlContext.Model.Save(model, trainingData.Schema, modelPath);

            Console.WriteLine($"Model successfully saved to: {modelPath}");
        }
    }


}