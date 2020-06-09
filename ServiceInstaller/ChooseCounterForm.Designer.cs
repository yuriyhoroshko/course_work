namespace ServiceInstaller
{
    partial class ChooseCounterForm
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
            this.categoriesDropBox = new System.Windows.Forms.ComboBox();
            this.labelCategories = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.instancesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.countersList = new System.Windows.Forms.ComboBox();
            this.testCounterButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.counterValue = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriesDropBox
            // 
            this.categoriesDropBox.FormattingEnabled = true;
            this.categoriesDropBox.Location = new System.Drawing.Point(12, 44);
            this.categoriesDropBox.Name = "categoriesDropBox";
            this.categoriesDropBox.Size = new System.Drawing.Size(476, 21);
            this.categoriesDropBox.TabIndex = 2;
            this.categoriesDropBox.DropDown += new System.EventHandler(this.categoriesDropBox_TextChanged);
            this.categoriesDropBox.SelectedIndexChanged += new System.EventHandler(this.categoriesDropBox_SelectedIndexChanged);
            // 
            // labelCategories
            // 
            this.labelCategories.AutoSize = true;
            this.labelCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategories.Location = new System.Drawing.Point(545, 44);
            this.labelCategories.Name = "labelCategories";
            this.labelCategories.Size = new System.Drawing.Size(243, 25);
            this.labelCategories.TabIndex = 3;
            this.labelCategories.Text = "Choose available category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(545, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose available instance";
            // 
            // instancesList
            // 
            this.instancesList.FormattingEnabled = true;
            this.instancesList.Location = new System.Drawing.Point(12, 114);
            this.instancesList.Name = "instancesList";
            this.instancesList.Size = new System.Drawing.Size(476, 21);
            this.instancesList.TabIndex = 4;
            this.instancesList.SelectedIndexChanged += new System.EventHandler(this.instancesList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(545, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose available counter";
            // 
            // countersList
            // 
            this.countersList.FormattingEnabled = true;
            this.countersList.Location = new System.Drawing.Point(12, 196);
            this.countersList.Name = "countersList";
            this.countersList.Size = new System.Drawing.Size(476, 21);
            this.countersList.TabIndex = 6;
            this.countersList.SelectedIndexChanged += new System.EventHandler(this.countersList_SelectedIndexChanged);
            // 
            // testCounterButton
            // 
            this.testCounterButton.Location = new System.Drawing.Point(12, 247);
            this.testCounterButton.Name = "testCounterButton";
            this.testCounterButton.Size = new System.Drawing.Size(202, 73);
            this.testCounterButton.TabIndex = 8;
            this.testCounterButton.Text = "Test";
            this.testCounterButton.UseVisualStyleBackColor = true;
            this.testCounterButton.Click += new System.EventHandler(this.testCounterButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(414, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Counter value:";
            // 
            // counterValue
            // 
            this.counterValue.AutoSize = true;
            this.counterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.counterValue.Location = new System.Drawing.Point(562, 269);
            this.counterValue.Name = "counterValue";
            this.counterValue.Size = new System.Drawing.Size(55, 24);
            this.counterValue.TabIndex = 10;
            this.counterValue.Text = "value";
            this.counterValue.Click += new System.EventHandler(this.label4_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(418, 344);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(370, 94);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 382);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Customn name:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(414, 311);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(279, 20);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "Counter with such name already exists";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(220, 300);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            0,
            256,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Customn Divider:";
            // 
            // ChooseCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.counterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.testCounterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countersList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.instancesList);
            this.Controls.Add(this.labelCategories);
            this.Controls.Add(this.categoriesDropBox);
            this.Name = "ChooseCounterForm";
            this.Text = "ChooseCounterForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoriesDropBox;
        private System.Windows.Forms.Label labelCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox instancesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox countersList;
        private System.Windows.Forms.Button testCounterButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label counterValue;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
    }
}

