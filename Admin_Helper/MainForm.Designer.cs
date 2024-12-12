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
            this.textBoxSolution = new System.Windows.Forms.TextBox();
            this.btnEditSolution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.btnDeleteProblem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxCategories.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 23;
            this.listBoxCategories.Location = new System.Drawing.Point(12, 38);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(403, 96);
            this.listBoxCategories.TabIndex = 0;
            // 
            // listBoxProblems
            // 
            this.listBoxProblems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProblems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxProblems.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxProblems.FormattingEnabled = true;
            this.listBoxProblems.ItemHeight = 23;
            this.listBoxProblems.Location = new System.Drawing.Point(438, 38);
            this.listBoxProblems.Name = "listBoxProblems";
            this.listBoxProblems.Size = new System.Drawing.Size(558, 96);
            this.listBoxProblems.TabIndex = 1;
            // 
            // textBoxSolution
            // 
            this.textBoxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSolution.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSolution.Location = new System.Drawing.Point(12, 226);
            this.textBoxSolution.Multiline = true;
            this.textBoxSolution.Name = "textBoxSolution";
            this.textBoxSolution.ReadOnly = true;
            this.textBoxSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSolution.Size = new System.Drawing.Size(984, 491);
            this.textBoxSolution.TabIndex = 5;
            this.textBoxSolution.Visible = false;
            // 
            // btnEditSolution
            // 
            this.btnEditSolution.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditSolution.Location = new System.Drawing.Point(12, 169);
            this.btnEditSolution.Name = "btnEditSolution";
            this.btnEditSolution.Size = new System.Drawing.Size(159, 51);
            this.btnEditSolution.TabIndex = 6;
            this.btnEditSolution.Text = "Редактировать решение";
            this.btnEditSolution.UseVisualStyleBackColor = true;
            this.btnEditSolution.Visible = false;
            this.btnEditSolution.Click += new System.EventHandler(this.btnEditSolution_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выбор категории:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.label2.Location = new System.Drawing.Point(438, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выбор проблемы:";
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveEdit.Location = new System.Drawing.Point(177, 169);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(159, 51);
            this.btnSaveEdit.TabIndex = 9;
            this.btnSaveEdit.Text = "Сохранить изменения";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddProblem.Location = new System.Drawing.Point(438, 140);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(131, 51);
            this.btnAddProblem.TabIndex = 10;
            this.btnAddProblem.Text = "Добавить проблему";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // btnDeleteProblem
            // 
            this.btnDeleteProblem.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteProblem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteProblem.Location = new System.Drawing.Point(575, 140);
            this.btnDeleteProblem.Name = "btnDeleteProblem";
            this.btnDeleteProblem.Size = new System.Drawing.Size(131, 51);
            this.btnDeleteProblem.TabIndex = 11;
            this.btnDeleteProblem.Text = "Удалить проблему";
            this.btnDeleteProblem.UseVisualStyleBackColor = false;
            this.btnDeleteProblem.Click += new System.EventHandler(this.btnDeleteProblem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnDeleteProblem);
            this.Controls.Add(this.btnAddProblem);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditSolution);
            this.Controls.Add(this.textBoxSolution);
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
        public System.Windows.Forms.TextBox textBoxSolution;
        private System.Windows.Forms.Button btnEditSolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnAddProblem;
        private System.Windows.Forms.Button btnDeleteProblem;
    }
}

