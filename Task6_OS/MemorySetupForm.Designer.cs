namespace Task6_OS
{
    partial class MemorySetupForm
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
            this.memorySizeField = new System.Windows.Forms.NumericUpDown();
            this.segmentSizeField = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memorySizeField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentSizeField)).BeginInit();
            this.SuspendLayout();
            // 
            // memorySizeField
            // 
            this.memorySizeField.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.memorySizeField.Location = new System.Drawing.Point(199, 65);
            this.memorySizeField.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.memorySizeField.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.memorySizeField.Name = "memorySizeField";
            this.memorySizeField.Size = new System.Drawing.Size(150, 27);
            this.memorySizeField.TabIndex = 0;
            this.memorySizeField.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // segmentSizeField
            // 
            this.segmentSizeField.Location = new System.Drawing.Point(199, 123);
            this.segmentSizeField.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.segmentSizeField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.segmentSizeField.Name = "segmentSizeField";
            this.segmentSizeField.Size = new System.Drawing.Size(150, 27);
            this.segmentSizeField.TabIndex = 1;
            this.segmentSizeField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Размер ОП (в Кб)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Размер сегмента (в Кб)";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(129, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 29);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MemorySetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 273);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.segmentSizeField);
            this.Controls.Add(this.memorySizeField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MemorySetupForm";
            this.Text = "Первичная настройка";
            ((System.ComponentModel.ISupportInitialize)(this.memorySizeField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentSizeField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown memorySizeField;
        private System.Windows.Forms.NumericUpDown segmentSizeField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
    }
}