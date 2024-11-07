namespace ClimateRepair
{
    partial class OperatorRequests
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
            this.operatorDGV = new System.Windows.Forms.DataGridView();
            this.RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Master_FullName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProblemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepairParts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CompletionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmButton = new System.Windows.Forms.Button();
            this.editTableButton = new System.Windows.Forms.Button();
            this.recordCountLabel = new System.Windows.Forms.Label();
            this.filterField1 = new System.Windows.Forms.TextBox();
            this.filterField2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.operatorDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // operatorDGV
            // 
            this.operatorDGV.AllowUserToAddRows = false;
            this.operatorDGV.AllowUserToDeleteRows = false;
            this.operatorDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operatorDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestID,
            this.StartDate,
            this.Client_FullName,
            this.Master_FullName,
            this.TypeName,
            this.Model,
            this.ProblemDescription,
            this.RepairParts,
            this.StatusName,
            this.CompletionDate});
            this.operatorDGV.Location = new System.Drawing.Point(31, 57);
            this.operatorDGV.Name = "operatorDGV";
            this.operatorDGV.ReadOnly = true;
            this.operatorDGV.Size = new System.Drawing.Size(905, 231);
            this.operatorDGV.TabIndex = 5;
            this.operatorDGV.SelectionChanged += new System.EventHandler(this.operatorDGV_SelectionChanged);
            // 
            // RequestID
            // 
            this.RequestID.HeaderText = "ID Заказа";
            this.RequestID.Name = "RequestID";
            this.RequestID.ReadOnly = true;
            this.RequestID.Width = 60;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Дата подачи";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 80;
            // 
            // Client_FullName
            // 
            this.Client_FullName.HeaderText = "Клиент";
            this.Client_FullName.Name = "Client_FullName";
            this.Client_FullName.ReadOnly = true;
            this.Client_FullName.Width = 80;
            // 
            // Master_FullName
            // 
            this.Master_FullName.HeaderText = "Мастер";
            this.Master_FullName.Name = "Master_FullName";
            this.Master_FullName.ReadOnly = true;
            this.Master_FullName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Master_FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Master_FullName.Width = 90;
            // 
            // TypeName
            // 
            this.TypeName.HeaderText = "Тип оборудования";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Модель";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // ProblemDescription
            // 
            this.ProblemDescription.HeaderText = "Проблема";
            this.ProblemDescription.Name = "ProblemDescription";
            this.ProblemDescription.ReadOnly = true;
            this.ProblemDescription.Width = 80;
            // 
            // RepairParts
            // 
            this.RepairParts.HeaderText = "Запчасти";
            this.RepairParts.Name = "RepairParts";
            this.RepairParts.ReadOnly = true;
            this.RepairParts.Width = 70;
            // 
            // StatusName
            // 
            this.StatusName.HeaderText = "Статус";
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            this.StatusName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CompletionDate
            // 
            this.CompletionDate.HeaderText = "Дата завершения";
            this.CompletionDate.Name = "CompletionDate";
            this.CompletionDate.ReadOnly = true;
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.SteelBlue;
            this.confirmButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(31, 294);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(180, 47);
            this.confirmButton.TabIndex = 21;
            this.confirmButton.Text = "Внести изменения";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Visible = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // editTableButton
            // 
            this.editTableButton.BackColor = System.Drawing.Color.SteelBlue;
            this.editTableButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editTableButton.ForeColor = System.Drawing.Color.White;
            this.editTableButton.Location = new System.Drawing.Point(756, 311);
            this.editTableButton.Name = "editTableButton";
            this.editTableButton.Size = new System.Drawing.Size(180, 47);
            this.editTableButton.TabIndex = 22;
            this.editTableButton.Text = "Редактировать";
            this.editTableButton.UseVisualStyleBackColor = false;
            this.editTableButton.Click += new System.EventHandler(this.editTableButton_Click);
            // 
            // recordCountLabel
            // 
            this.recordCountLabel.AutoSize = true;
            this.recordCountLabel.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.recordCountLabel.Location = new System.Drawing.Point(878, 23);
            this.recordCountLabel.Name = "recordCountLabel";
            this.recordCountLabel.Size = new System.Drawing.Size(45, 19);
            this.recordCountLabel.TabIndex = 23;
            this.recordCountLabel.Text = "label1";
            // 
            // filterField1
            // 
            this.filterField1.Location = new System.Drawing.Point(111, 31);
            this.filterField1.Name = "filterField1";
            this.filterField1.Size = new System.Drawing.Size(100, 20);
            this.filterField1.TabIndex = 24;
            this.filterField1.TextChanged += new System.EventHandler(this.filterField_TextChanged);
            // 
            // filterField2
            // 
            this.filterField2.Location = new System.Drawing.Point(290, 31);
            this.filterField2.Name = "filterField2";
            this.filterField2.Size = new System.Drawing.Size(100, 20);
            this.filterField2.TabIndex = 25;
            this.filterField2.TextChanged += new System.EventHandler(this.filterField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Фильтровать по:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(38, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Клиенту";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(218, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Мастеру";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(12, 352);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(180, 39);
            this.BackButton.TabIndex = 29;
            this.BackButton.Text = "Вернуться назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OperatorRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 403);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterField2);
            this.Controls.Add(this.filterField1);
            this.Controls.Add(this.recordCountLabel);
            this.Controls.Add(this.editTableButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.operatorDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OperatorRequests";
            this.TextChanged += new System.EventHandler(this.filterField_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.operatorDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView operatorDGV;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button editTableButton;
        private System.Windows.Forms.Label recordCountLabel;
        private System.Windows.Forms.TextBox filterField1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_FullName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Master_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProblemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepairParts;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompletionDate;
        private System.Windows.Forms.TextBox filterField2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BackButton;
    }
}