namespace ClimateRepair
{
    partial class LoginHistory
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
            this.LogHDGV = new System.Windows.Forms.DataGridView();
            this.filterField1 = new System.Windows.Forms.TextBox();
            this.recordLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.HistoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSuccessful = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogHDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LogHDGV
            // 
            this.LogHDGV.AllowUserToAddRows = false;
            this.LogHDGV.AllowUserToDeleteRows = false;
            this.LogHDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogHDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HistoryID,
            this.LoginTime,
            this.UserLogin,
            this.IsSuccessful});
            this.LogHDGV.Location = new System.Drawing.Point(45, 81);
            this.LogHDGV.Name = "LogHDGV";
            this.LogHDGV.ReadOnly = true;
            this.LogHDGV.Size = new System.Drawing.Size(593, 210);
            this.LogHDGV.TabIndex = 0;
            // 
            // filterField1
            // 
            this.filterField1.Location = new System.Drawing.Point(132, 33);
            this.filterField1.Name = "filterField1";
            this.filterField1.Size = new System.Drawing.Size(100, 20);
            this.filterField1.TabIndex = 1;
            this.filterField1.TextChanged += new System.EventHandler(this.filterField_TextChanged);
            // 
            // recordLabel
            // 
            this.recordLabel.AutoSize = true;
            this.recordLabel.Location = new System.Drawing.Point(524, 33);
            this.recordLabel.Name = "recordLabel";
            this.recordLabel.Size = new System.Drawing.Size(35, 13);
            this.recordLabel.TabIndex = 2;
            this.recordLabel.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(59, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "Логину";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Фильтровать по:";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(12, 315);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(180, 39);
            this.BackButton.TabIndex = 30;
            this.BackButton.Text = "Вернуться назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HistoryID
            // 
            this.HistoryID.HeaderText = "ID Попытки";
            this.HistoryID.Name = "HistoryID";
            this.HistoryID.ReadOnly = true;
            // 
            // LoginTime
            // 
            this.LoginTime.HeaderText = "Дата попытки";
            this.LoginTime.Name = "LoginTime";
            this.LoginTime.ReadOnly = true;
            this.LoginTime.Width = 150;
            // 
            // UserLogin
            // 
            this.UserLogin.HeaderText = "Логин";
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.ReadOnly = true;
            this.UserLogin.Width = 150;
            // 
            // IsSuccessful
            // 
            this.IsSuccessful.HeaderText = "Вошел";
            this.IsSuccessful.Name = "IsSuccessful";
            this.IsSuccessful.ReadOnly = true;
            this.IsSuccessful.Width = 150;
            // 
            // LoginHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 368);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recordLabel);
            this.Controls.Add(this.filterField1);
            this.Controls.Add(this.LogHDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginHistory";
            ((System.ComponentModel.ISupportInitialize)(this.LogHDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView LogHDGV;
        private System.Windows.Forms.TextBox filterField1;
        private System.Windows.Forms.Label recordLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSuccessful;
    }
}