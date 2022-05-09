namespace Task6_OS
{
    partial class MainForm
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
            this.compactMemoryButton = new System.Windows.Forms.Button();
            this.memoryList = new System.Windows.Forms.ListView();
            this.processIdColumn1 = new System.Windows.Forms.ColumnHeader();
            this.processSizeColumn1 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.swapList = new System.Windows.Forms.ListView();
            this.processIdColumn2 = new System.Windows.Forms.ColumnHeader();
            this.processSizeColumn2 = new System.Windows.Forms.ColumnHeader();
            this.unloadButton = new System.Windows.Forms.Button();
            this.toSwapButton = new System.Windows.Forms.Button();
            this.fromSwapButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.processSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.processSizeUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // compactMemoryButton
            // 
            this.compactMemoryButton.Location = new System.Drawing.Point(12, 364);
            this.compactMemoryButton.Name = "compactMemoryButton";
            this.compactMemoryButton.Size = new System.Drawing.Size(170, 29);
            this.compactMemoryButton.TabIndex = 0;
            this.compactMemoryButton.Text = "Уплотнить память";
            this.compactMemoryButton.UseVisualStyleBackColor = true;
            this.compactMemoryButton.Click += new System.EventHandler(this.compactMemoryButton_Click);
            // 
            // memoryList
            // 
            this.memoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processIdColumn1,
            this.processSizeColumn1});
            this.memoryList.HideSelection = false;
            this.memoryList.Location = new System.Drawing.Point(785, 28);
            this.memoryList.Name = "memoryList";
            this.memoryList.Size = new System.Drawing.Size(203, 159);
            this.memoryList.TabIndex = 1;
            this.memoryList.UseCompatibleStateImageBehavior = false;
            this.memoryList.View = System.Windows.Forms.View.Details;
            // 
            // processIdColumn1
            // 
            this.processIdColumn1.Text = "ID";
            // 
            // processSizeColumn1
            // 
            this.processSizeColumn1.Text = "Размер";
            this.processSizeColumn1.Width = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(785, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Процессы в памяти";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1046, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Процессы в swap-файле";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Визуализация памяти";
            // 
            // swapList
            // 
            this.swapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processIdColumn2,
            this.processSizeColumn2});
            this.swapList.HideSelection = false;
            this.swapList.Location = new System.Drawing.Point(1052, 28);
            this.swapList.Name = "swapList";
            this.swapList.Size = new System.Drawing.Size(203, 159);
            this.swapList.TabIndex = 6;
            this.swapList.UseCompatibleStateImageBehavior = false;
            this.swapList.View = System.Windows.Forms.View.Details;
            // 
            // processIdColumn2
            // 
            this.processIdColumn2.Text = "ID";
            // 
            // processSizeColumn2
            // 
            this.processSizeColumn2.Text = "Размер";
            this.processSizeColumn2.Width = 110;
            // 
            // unloadButton
            // 
            this.unloadButton.Enabled = false;
            this.unloadButton.Location = new System.Drawing.Point(785, 193);
            this.unloadButton.Name = "unloadButton";
            this.unloadButton.Size = new System.Drawing.Size(102, 29);
            this.unloadButton.TabIndex = 7;
            this.unloadButton.Text = "Завершить";
            this.unloadButton.UseVisualStyleBackColor = true;
            // 
            // toSwapButton
            // 
            this.toSwapButton.Enabled = false;
            this.toSwapButton.Location = new System.Drawing.Point(999, 75);
            this.toSwapButton.Name = "toSwapButton";
            this.toSwapButton.Size = new System.Drawing.Size(41, 29);
            this.toSwapButton.TabIndex = 8;
            this.toSwapButton.Text = "=>";
            this.toSwapButton.UseVisualStyleBackColor = true;
            // 
            // fromSwapButton
            // 
            this.fromSwapButton.Enabled = false;
            this.fromSwapButton.Location = new System.Drawing.Point(999, 110);
            this.fromSwapButton.Name = "fromSwapButton";
            this.fromSwapButton.Size = new System.Drawing.Size(41, 29);
            this.fromSwapButton.TabIndex = 9;
            this.fromSwapButton.Text = "<=";
            this.fromSwapButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 79);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(94, 29);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // processSizeUpDown
            // 
            this.processSizeUpDown.Location = new System.Drawing.Point(6, 46);
            this.processSizeUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.processSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.processSizeUpDown.Name = "processSizeUpDown";
            this.processSizeUpDown.Size = new System.Drawing.Size(150, 27);
            this.processSizeUpDown.TabIndex = 11;
            this.processSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Размер процесса в байтах";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Controls.Add(this.processSizeUpDown);
            this.groupBox1.Location = new System.Drawing.Point(790, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 125);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новый процесс";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fromSwapButton);
            this.Controls.Add(this.toSwapButton);
            this.Controls.Add(this.unloadButton);
            this.Controls.Add(this.swapList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memoryList);
            this.Controls.Add(this.compactMemoryButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processSizeUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compactMemoryButton;
        private System.Windows.Forms.ListView memoryList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader processIdColumn1;
        private System.Windows.Forms.ColumnHeader processSizeColumn1;
        private System.Windows.Forms.ListView swapList;
        private System.Windows.Forms.ColumnHeader processIdColumn2;
        private System.Windows.Forms.ColumnHeader processSizeColumn2;
        private System.Windows.Forms.Button unloadButton;
        private System.Windows.Forms.Button toSwapButton;
        private System.Windows.Forms.Button fromSwapButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.NumericUpDown processSizeUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
