using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace EmotionApp
{
    public partial class Form1 : Form
    {
        private bool _isDevMode = false;
        private MLContext _mlContext;
        private ITransformer _trainedModel;
        private PredictionEngine<EmotionInput, EmotionOutput> _predictionEngine;

        public Form1()
        {
            InitializeComponent();
            _mlContext = new MLContext();
        }

        /// <summary>
        /// Handles the Train Model operation.
        /// </summary>
        private async void btnTrain_Click(object sender, EventArgs e)
        {
            string dataPath = Path.Combine(Application.StartupPath, "emotions.txt");
            string modelPath = Path.Combine(Application.StartupPath, "emotion_model.zip");

            if (!File.Exists(dataPath))
            {
                MessageBox.Show("Cannot find emotions.txt! Please ensure it is placed in the project directory.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTrain.Enabled = false;
            btnTrain.Text = "Training...";

            try
            {
                // Run training on a background thread
                await Task.Run(() => ModelTrainer.TrainModel(dataPath, modelPath));

                // Clear the engine because the model just changed
                _predictionEngine = null;

                MessageBox.Show("AI Model trained and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error training model: {ex.Message}", "Training Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTrain.Enabled = true;
                btnTrain.Text = "Train Model";
            }
        }

        /// <summary>
        /// Handles the Analyze button click event (Full Analyzer).
        /// </summary>
        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            string modelPath = Path.Combine(Application.StartupPath, "emotion_model.zip");

            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Please enter some text to analyze first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ⭐ FIX: Check if model exists BEFORE attempting to load the engine!
            if (!File.Exists(modelPath))
            {
                MessageBox.Show("Please train the model first before analyzing text.", "Model Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lazily load the Prediction Engine if it's not loaded yet
                if (_predictionEngine == null)
                {
                    await Task.Run(() =>
                    {
                        _trainedModel = _mlContext.Model.Load(modelPath, out _);
                        _predictionEngine = _mlContext.Model.CreatePredictionEngine<EmotionInput, EmotionOutput>(_trainedModel);
                    });
                }

                // Create prediction
                var input = new EmotionInput { Text = txtInput.Text };
                var prediction = _predictionEngine.Predict(input);

                if (!_isDevMode)
                {
                    // Standard Mode: Just show the top result
                    lblResult.Text = $"Detected Emotion: {prediction.Emotion}";
                }
                else
                {
                    // Developer Mode: Show the distribution of all emotion scores!
                    lblResult.Text = GetDetailedScores(prediction);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error making prediction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Helper method for Dev Mode to extract probabilities of all categories.
        /// </summary>
        private string GetDetailedScores(EmotionOutput prediction)
        {
            string result = $"Top Prediction: {prediction.Emotion}\n\nAll Scores:\n";

            try
            {
                // ML.NET stores category names in the Schema annotations
                var column = _predictionEngine.OutputSchema["Score"];
                var labelBuffer = new VBuffer<ReadOnlyMemory<char>>();
                column.Annotations.GetValue("SlotNames", ref labelBuffer);

                var labels = labelBuffer.DenseValues().Select(l => l.ToString()).ToArray();

                // Link labels with their percentage scores
                var scoresWithLabels = new Dictionary<string, float>();
                for (int i = 0; i < labels.Length; i++)
                {
                    scoresWithLabels.Add(labels[i], prediction.Score[i]);
                }

                // Sort descending so the highest percentage is at the top
                foreach (var kvp in scoresWithLabels.OrderByDescending(x => x.Value))
                {
                    result += $"{kvp.Key}: {kvp.Value * 100:0.00}%\n";
                }
            }
            catch
            {
                result += "Unable to extract multi-class score mapping.";
            }

            return result;
        }

        /// <summary>
        /// Handles the Developer Mode button click event with Password Protection.
        /// </summary>
        private void btnDevMode_Click(object sender, EventArgs e)
        {
            // If Dev Mode is already ON, turn it off without asking for a password
            if (_isDevMode)
            {
                _isDevMode = false;
                btnDevMode.Text = "Developer Mode";
                pnlDeveloper.Visible = false; // Hide the developer tools panel
                MessageBox.Show("Developer Mode disabled. Returning to standard single-emotion output.", "Dev Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Creating a quick prompt for the password using visual basic interaction
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter Developer Password:", "Authentication Required", "");

            // Change your password here!
            if (password == "admin123")
            {
                _isDevMode = true;
                btnDevMode.Text = "Dev Mode: ON";
                pnlDeveloper.Visible = true; // Reveal the hidden developer panel!

                MessageBox.Show("Developer Mode enabled! You can now view multi-class scores and train the model.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Incorrect password. Access denied.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // --- REPAIRED DATA CLASSES MAPPED TO YOUR TRAINER ---

    public class EmotionInput
    {
        public string Text { get; set; }
        public string Emotion { get; set; } // Add this if required by the model
    }

    public class EmotionOutput
    {
        [ColumnName("PredictedLabel")]
        public string Emotion { get; set; }

        [ColumnName("Score")]
        public float[] Score { get; set; }
    }
}