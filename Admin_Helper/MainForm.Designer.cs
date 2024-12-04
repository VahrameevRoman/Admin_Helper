namespace Admin_Helper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.listBoxProblems = new System.Windows.Forms.ListBox();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.textBoxSolution = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxCategories.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 23;
            this.listBoxCategories.Location = new System.Drawing.Point(12, 65);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(558, 96);
            this.listBoxCategories.TabIndex = 0;
            // 
            // listBoxProblems
            // 
            this.listBoxProblems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxProblems.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxProblems.FormattingEnabled = true;
            this.listBoxProblems.ItemHeight = 23;
            this.listBoxProblems.Location = new System.Drawing.Point(12, 197);
            this.listBoxProblems.Name = "listBoxProblems";
            this.listBoxProblems.Size = new System.Drawing.Size(558, 96);
            this.listBoxProblems.TabIndex = 1;
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowSolution.Location = new System.Drawing.Point(605, 248);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(169, 45);
            this.btnShowSolution.TabIndex = 4;
            this.btnShowSolution.Text = "Показать решение";
            this.btnShowSolution.UseVisualStyleBackColor = true;
            this.btnShowSolution.Click += new System.EventHandler(this.btnShowSolution_Click);
            // 
            // textBoxSolution
            // 
            this.textBoxSolution.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSolution.Location = new System.Drawing.Point(12, 336);
            this.textBoxSolution.Multiline = true;
            this.textBoxSolution.Name = "textBoxSolution";
            this.textBoxSolution.ReadOnly = true;
            this.textBoxSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSolution.Size = new System.Drawing.Size(971, 381);
            this.textBoxSolution.TabIndex = 5;
            this.textBoxSolution.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.textBoxSolution);
            this.Controls.Add(this.btnShowSolution);
            this.Controls.Add(this.listBoxProblems);
            this.Controls.Add(this.listBoxCategories);
            this.Name = "MainForm";
            this.Text = "Administrative assistant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.ListBox listBoxProblems;
        private System.Windows.Forms.Button btnShowSolution;
        public System.Windows.Forms.TextBox textBoxSolution;
    }
}

