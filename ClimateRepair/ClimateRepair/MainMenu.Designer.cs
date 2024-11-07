namespace ClimateRepair
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel2 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.usLogLabel = new System.Windows.Forms.Label();
            this.ProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.profileButton = new System.Windows.Forms.Button();
            this.addRequestButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.historyButton = new System.Windows.Forms.Button();
            this.operatorReqButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Controls.Add(this.usLogLabel);
            this.panel2.Controls.Add(this.ProfilePictureBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 157);
            this.panel2.TabIndex = 2;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.backButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(531, 120);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(113, 32);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Выйти";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // usLogLabel
            // 
            this.usLogLabel.AutoSize = true;
            this.usLogLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usLogLabel.ForeColor = System.Drawing.Color.White;
            this.usLogLabel.Location = new System.Drawing.Point(565, 97);
            this.usLogLabel.Name = "usLogLabel";
            this.usLogLabel.Size = new System.Drawing.Size(49, 19);
            this.usLogLabel.TabIndex = 9;
            this.usLogLabel.Text = "label2";
            // 
            // ProfilePictureBox
            // 
            this.ProfilePictureBox.Location = new System.Drawing.Point(539, 7);
            this.ProfilePictureBox.Name = "ProfilePictureBox";
            this.ProfilePictureBox.Size = new System.Drawing.Size(100, 87);
            this.ProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePictureBox.TabIndex = 8;
            this.ProfilePictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Elephant", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(123, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "ClimateRepair";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.SteelBlue;
            this.profileButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.profileButton.ForeColor = System.Drawing.Color.White;
            this.profileButton.Location = new System.Drawing.Point(222, 225);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(222, 55);
            this.profileButton.TabIndex = 8;
            this.profileButton.Text = "Мой профиль";
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // addRequestButton
            // 
            this.addRequestButton.BackColor = System.Drawing.Color.SteelBlue;
            this.addRequestButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRequestButton.ForeColor = System.Drawing.Color.White;
            this.addRequestButton.Location = new System.Drawing.Point(222, 296);
            this.addRequestButton.Name = "addRequestButton";
            this.addRequestButton.Size = new System.Drawing.Size(222, 55);
            this.addRequestButton.TabIndex = 9;
            this.addRequestButton.Text = "Подать заявку";
            this.addRequestButton.UseVisualStyleBackColor = false;
            this.addRequestButton.Click += new System.EventHandler(this.addRequestButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.SteelBlue;
            this.aboutButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutButton.ForeColor = System.Drawing.Color.White;
            this.aboutButton.Location = new System.Drawing.Point(222, 366);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(222, 55);
            this.aboutButton.TabIndex = 10;
            this.aboutButton.Text = "Справка";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(236, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Главное меню";
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.SteelBlue;
            this.historyButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.historyButton.ForeColor = System.Drawing.Color.White;
            this.historyButton.Location = new System.Drawing.Point(222, 438);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(222, 55);
            this.historyButton.TabIndex = 12;
            this.historyButton.Text = "История входа";
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // operatorReqButton
            // 
            this.operatorReqButton.BackColor = System.Drawing.Color.SteelBlue;
            this.operatorReqButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operatorReqButton.ForeColor = System.Drawing.Color.White;
            this.operatorReqButton.Location = new System.Drawing.Point(450, 296);
            this.operatorReqButton.Name = "operatorReqButton";
            this.operatorReqButton.Size = new System.Drawing.Size(222, 55);
            this.operatorReqButton.TabIndex = 13;
            this.operatorReqButton.Text = "Заявки";
            this.operatorReqButton.UseVisualStyleBackColor = false;
            this.operatorReqButton.Click += new System.EventHandler(this.operatorReqButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 519);
            this.Controls.Add(this.operatorReqButton);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.addRequestButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button addRequestButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ProfilePictureBox;
        private System.Windows.Forms.Label usLogLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button operatorReqButton;
    }
}