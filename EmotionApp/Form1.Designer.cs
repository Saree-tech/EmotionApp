namespace EmotionApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtInput = new TextBox();
            btnAnalyze = new Button();
            lblResult = new Label();
            btnDevMode = new Button();
            pnlDeveloper = new Panel();
            btnTrain = new Button();
            lblDevTitle = new Label();
            pnlDeveloper.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 48);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "EMOTION AI";
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.FromArgb(45, 45, 48);
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.ForeColor = Color.White;
            txtInput.Location = new Point(35, 80);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Type how you are feeling here...";
            txtInput.Size = new Size(530, 150);
            txtInput.TabIndex = 2;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.FromArgb(0, 122, 255);
            btnAnalyze.FlatAppearance.BorderSize = 0;
            btnAnalyze.FlatStyle = FlatStyle.Flat;
            btnAnalyze.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnalyze.ForeColor = Color.White;
            btnAnalyze.Location = new Point(35, 245);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(530, 45);
            btnAnalyze.TabIndex = 3;
            btnAnalyze.Text = "Analyze Emotion";
            btnAnalyze.UseVisualStyleBackColor = false;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.ForeColor = Color.FromArgb(150, 150, 150);
            lblResult.Location = new Point(35, 310);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(271, 45);
            lblResult.TabIndex = 4;
            lblResult.Text = "Awaiting Input...";
            // 
            // btnDevMode
            // 
            btnDevMode.BackColor = Color.FromArgb(45, 45, 48);
            btnDevMode.FlatAppearance.BorderSize = 0;
            btnDevMode.FlatStyle = FlatStyle.Flat;
            btnDevMode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDevMode.ForeColor = Color.Gray;
            btnDevMode.Location = new Point(35, 367);
            btnDevMode.Name = "btnDevMode";
            btnDevMode.Size = new Size(150, 30);
            btnDevMode.TabIndex = 5;
            btnDevMode.Text = "Developer Mode";
            btnDevMode.UseVisualStyleBackColor = false;
            btnDevMode.Click += btnDevMode_Click;
            // 
            // pnlDeveloper
            // 
            pnlDeveloper.BackColor = Color.FromArgb(40, 40, 40);
            pnlDeveloper.Controls.Add(btnTrain);
            pnlDeveloper.Controls.Add(lblDevTitle);
            pnlDeveloper.Location = new Point(590, 80);
            pnlDeveloper.Name = "pnlDeveloper";
            pnlDeveloper.Size = new Size(180, 150);
            pnlDeveloper.TabIndex = 6;
            pnlDeveloper.Visible = false;
            // 
            // btnTrain
            // 
            btnTrain.BackColor = Color.FromArgb(255, 149, 0);
            btnTrain.FlatAppearance.BorderSize = 0;
            btnTrain.FlatStyle = FlatStyle.Flat;
            btnTrain.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrain.ForeColor = Color.White;
            btnTrain.Location = new Point(15, 60);
            btnTrain.Name = "btnTrain";
            btnTrain.Size = new Size(150, 40);
            btnTrain.TabIndex = 0;
            btnTrain.Text = "Train Model";
            btnTrain.UseVisualStyleBackColor = false;
            btnTrain.Click += btnTrain_Click;
            // 
            // lblDevTitle
            // 
            lblDevTitle.AutoSize = true;
            lblDevTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDevTitle.ForeColor = Color.White;
            lblDevTitle.Location = new Point(15, 15);
            lblDevTitle.Name = "lblDevTitle";
            lblDevTitle.Size = new Size(148, 25);
            lblDevTitle.TabIndex = 1;
            lblDevTitle.Text = "Developer Tools";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(pnlDeveloper);
            Controls.Add(btnDevMode);
            Controls.Add(lblResult);
            Controls.Add(btnAnalyze);
            Controls.Add(txtInput);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "AI Emotion Detector";
            pnlDeveloper.ResumeLayout(false);
            pnlDeveloper.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTrain;
        private Label lblTitle;
        private TextBox txtInput;
        private Button btnAnalyze;
        private Label lblResult;
        private Button btnDevMode;
        private Panel pnlDeveloper;
        private Label lblDevTitle;
    }
}