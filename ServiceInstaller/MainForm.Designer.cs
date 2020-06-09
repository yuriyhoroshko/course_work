namespace ServiceInstaller
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addCounterButton = new System.Windows.Forms.Button();
            this.addedList = new System.Windows.Forms.ListBox();
            this.collectionSeconds = new System.Windows.Forms.NumericUpDown();
            this.dataUploadMinutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dirLabel = new System.Windows.Forms.Label();
            this.installBtn = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.pcNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.collectionSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUploadMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // addCounterButton
            // 
            this.addCounterButton.Location = new System.Drawing.Point(655, 12);
            this.addCounterButton.Name = "addCounterButton";
            this.addCounterButton.Size = new System.Drawing.Size(133, 186);
            this.addCounterButton.TabIndex = 1;
            this.addCounterButton.Text = "Add Counter";
            this.addCounterButton.UseVisualStyleBackColor = true;
            this.addCounterButton.Click += new System.EventHandler(this.addCounterButton_Click);
            // 
            // addedList
            // 
            this.addedList.FormattingEnabled = true;
            this.addedList.Location = new System.Drawing.Point(12, 12);
            this.addedList.Name = "addedList";
            this.addedList.Size = new System.Drawing.Size(637, 186);
            this.addedList.TabIndex = 2;
            // 
            // collectionSeconds
            // 
            this.collectionSeconds.Location = new System.Drawing.Point(668, 225);
            this.collectionSeconds.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.collectionSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.collectionSeconds.Name = "collectionSeconds";
            this.collectionSeconds.Size = new System.Drawing.Size(120, 20);
            this.collectionSeconds.TabIndex = 3;
            this.collectionSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.collectionSeconds.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // dataUploadMinutes
            // 
            this.dataUploadMinutes.Location = new System.Drawing.Point(668, 310);
            this.dataUploadMinutes.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.dataUploadMinutes.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.dataUploadMinutes.Name = "dataUploadMinutes";
            this.dataUploadMinutes.Size = new System.Drawing.Size(120, 20);
            this.dataUploadMinutes.TabIndex = 4;
            this.dataUploadMinutes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.dataUploadMinutes.ValueChanged += new System.EventHandler(this.dataUploadMinutes_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(413, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Counter data collection (sec)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(427, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data upload to server (min)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 72);
            this.button1.TabIndex = 7;
            this.button1.Text = "Choose directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dirLabel
            // 
            this.dirLabel.AutoSize = true;
            this.dirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dirLabel.Location = new System.Drawing.Point(152, 388);
            this.dirLabel.Name = "dirLabel";
            this.dirLabel.Size = new System.Drawing.Size(352, 24);
            this.dirLabel.TabIndex = 8;
            this.dirLabel.Text = "You need to specify data saving directory";
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(654, 366);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(134, 72);
            this.installBtn.TabIndex = 9;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 221);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(134, 45);
            this.loginButton.TabIndex = 10;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.Location = new System.Drawing.Point(152, 229);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(118, 24);
            this.loginLabel.TabIndex = 11;
            this.loginLabel.Text = "Please, login";
            // 
            // pcNameTextBox
            // 
            this.pcNameTextBox.Location = new System.Drawing.Point(13, 310);
            this.pcNameTextBox.Name = "pcNameTextBox";
            this.pcNameTextBox.Size = new System.Drawing.Size(408, 20);
            this.pcNameTextBox.TabIndex = 12;
            this.pcNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pcNameTextBox);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.dirLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataUploadMinutes);
            this.Controls.Add(this.collectionSeconds);
            this.Controls.Add(this.addedList);
            this.Controls.Add(this.addCounterButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.collectionSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUploadMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addCounterButton;
        private System.Windows.Forms.ListBox addedList;
        private System.Windows.Forms.NumericUpDown collectionSeconds;
        private System.Windows.Forms.NumericUpDown dataUploadMinutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dirLabel;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox pcNameTextBox;
    }
}