namespace ClimateRepair
{
    partial class CreateRequest
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.eqTypeComboBox = new System.Windows.Forms.ComboBox();
            this.equipmentTypesBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.oleksenkoPractDataSetlocalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oleksenkoPractDataSet_local = new ClimateRepair.OleksenkoPractDataSet_local();
            this.equipmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oleksenkoPractDataSet = new ClimateRepair.OleksenkoPractDataSet();
            this.eqModelTextBox = new System.Windows.Forms.TextBox();
            this.descriptTextBox = new System.Windows.Forms.TextBox();
            this.fioTextBox = new System.Windows.Forms.TextBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.oleksenkoPractDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTypesTableAdapter = new ClimateRepair.OleksenkoPractDataSetTableAdapters.EquipmentTypesTableAdapter();
            this.equipmentTypesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fKEquipmentTypeI7C4F7684BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTableAdapter = new ClimateRepair.OleksenkoPractDataSetTableAdapters.EquipmentTableAdapter();
            this.equipmentTypesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTypesTableAdapter1 = new ClimateRepair.OleksenkoPractDataSet_localTableAdapters.EquipmentTypesTableAdapter();
            this.equipmentTypesBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.fKEquipmentTypeI412EB0B6BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTableAdapter1 = new ClimateRepair.OleksenkoPractDataSet_localTableAdapters.EquipmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSetlocalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSet_local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKEquipmentTypeI7C4F7684BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKEquipmentTypeI412EB0B6BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(193, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Создание заявки";
            // 
            // eqTypeComboBox
            // 
            this.eqTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eqTypeComboBox.FormattingEnabled = true;
            this.eqTypeComboBox.Location = new System.Drawing.Point(196, 120);
            this.eqTypeComboBox.Name = "eqTypeComboBox";
            this.eqTypeComboBox.Size = new System.Drawing.Size(229, 29);
            this.eqTypeComboBox.TabIndex = 14;
            this.eqTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CheckFields);
            // 
            // equipmentTypesBindingSource3
            // 
            this.equipmentTypesBindingSource3.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource3.DataSource = this.oleksenkoPractDataSetlocalBindingSource;
            // 
            // oleksenkoPractDataSetlocalBindingSource
            // 
            this.oleksenkoPractDataSetlocalBindingSource.DataSource = this.oleksenkoPractDataSet_local;
            this.oleksenkoPractDataSetlocalBindingSource.Position = 0;
            // 
            // oleksenkoPractDataSet_local
            // 
            this.oleksenkoPractDataSet_local.DataSetName = "OleksenkoPractDataSet_local";
            this.oleksenkoPractDataSet_local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // equipmentTypesBindingSource
            // 
            this.equipmentTypesBindingSource.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource.DataSource = this.oleksenkoPractDataSet;
            // 
            // oleksenkoPractDataSet
            // 
            this.oleksenkoPractDataSet.DataSetName = "OleksenkoPractDataSet";
            this.oleksenkoPractDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eqModelTextBox
            // 
            this.eqModelTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eqModelTextBox.Location = new System.Drawing.Point(196, 180);
            this.eqModelTextBox.Name = "eqModelTextBox";
            this.eqModelTextBox.Size = new System.Drawing.Size(229, 29);
            this.eqModelTextBox.TabIndex = 15;
            this.eqModelTextBox.TextChanged += new System.EventHandler(this.CheckFields);
            // 
            // descriptTextBox
            // 
            this.descriptTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptTextBox.Location = new System.Drawing.Point(196, 243);
            this.descriptTextBox.Multiline = true;
            this.descriptTextBox.Name = "descriptTextBox";
            this.descriptTextBox.Size = new System.Drawing.Size(229, 66);
            this.descriptTextBox.TabIndex = 16;
            this.descriptTextBox.TextChanged += new System.EventHandler(this.CheckFields);
            // 
            // fioTextBox
            // 
            this.fioTextBox.Enabled = false;
            this.fioTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fioTextBox.Location = new System.Drawing.Point(196, 340);
            this.fioTextBox.Name = "fioTextBox";
            this.fioTextBox.Size = new System.Drawing.Size(229, 29);
            this.fioTextBox.TabIndex = 17;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Enabled = false;
            this.contactTextBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contactTextBox.Location = new System.Drawing.Point(196, 407);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(229, 32);
            this.contactTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(192, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Тип оборудования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(192, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Модель оборудования";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(192, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Описание проблемы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(192, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Контактное лицо";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(192, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Контактный номер телефона";
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.confirmButton.Enabled = false;
            this.confirmButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(224, 462);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(171, 48);
            this.confirmButton.TabIndex = 24;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.SteelBlue;
            this.backButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(12, 488);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(148, 38);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Вернуться назад";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // oleksenkoPractDataSetBindingSource
            // 
            this.oleksenkoPractDataSetBindingSource.DataSource = this.oleksenkoPractDataSet;
            this.oleksenkoPractDataSetBindingSource.Position = 0;
            // 
            // equipmentTypesTableAdapter
            // 
            this.equipmentTypesTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentTypesBindingSource1
            // 
            this.equipmentTypesBindingSource1.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource1.DataSource = this.oleksenkoPractDataSetBindingSource;
            // 
            // fKEquipmentTypeI7C4F7684BindingSource
            // 
            this.fKEquipmentTypeI7C4F7684BindingSource.DataMember = "FK__Equipment__TypeI__7C4F7684";
            this.fKEquipmentTypeI7C4F7684BindingSource.DataSource = this.equipmentTypesBindingSource1;
            // 
            // equipmentTableAdapter
            // 
            this.equipmentTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentTypesBindingSource2
            // 
            this.equipmentTypesBindingSource2.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource2.DataSource = this.oleksenkoPractDataSetBindingSource;
            // 
            // equipmentTypesTableAdapter1
            // 
            this.equipmentTypesTableAdapter1.ClearBeforeFill = true;
            // 
            // equipmentTypesBindingSource4
            // 
            this.equipmentTypesBindingSource4.DataMember = "EquipmentTypes";
            this.equipmentTypesBindingSource4.DataSource = this.oleksenkoPractDataSetlocalBindingSource;
            // 
            // fKEquipmentTypeI412EB0B6BindingSource
            // 
            this.fKEquipmentTypeI412EB0B6BindingSource.DataMember = "FK__Equipment__TypeI__412EB0B6";
            this.fKEquipmentTypeI412EB0B6BindingSource.DataSource = this.equipmentTypesBindingSource4;
            // 
            // equipmentTableAdapter1
            // 
            this.equipmentTableAdapter1.ClearBeforeFill = true;
            // 
            // CreateRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(624, 538);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.fioTextBox);
            this.Controls.Add(this.descriptTextBox);
            this.Controls.Add(this.eqModelTextBox);
            this.Controls.Add(this.eqTypeComboBox);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateRequest";
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSetlocalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSet_local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleksenkoPractDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKEquipmentTypeI7C4F7684BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentTypesBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKEquipmentTypeI412EB0B6BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox eqTypeComboBox;
        private System.Windows.Forms.TextBox eqModelTextBox;
        private System.Windows.Forms.TextBox descriptTextBox;
        private System.Windows.Forms.TextBox fioTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.BindingSource oleksenkoPractDataSetBindingSource;
        private OleksenkoPractDataSet oleksenkoPractDataSet;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource;
        private OleksenkoPractDataSetTableAdapters.EquipmentTypesTableAdapter equipmentTypesTableAdapter;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource1;
        private System.Windows.Forms.BindingSource fKEquipmentTypeI7C4F7684BindingSource;
        private OleksenkoPractDataSetTableAdapters.EquipmentTableAdapter equipmentTableAdapter;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource2;
        private System.Windows.Forms.BindingSource oleksenkoPractDataSetlocalBindingSource;
        private OleksenkoPractDataSet_local oleksenkoPractDataSet_local;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource3;
        private OleksenkoPractDataSet_localTableAdapters.EquipmentTypesTableAdapter equipmentTypesTableAdapter1;
        private System.Windows.Forms.BindingSource equipmentTypesBindingSource4;
        private System.Windows.Forms.BindingSource fKEquipmentTypeI412EB0B6BindingSource;
        private OleksenkoPractDataSet_localTableAdapters.EquipmentTableAdapter equipmentTableAdapter1;
    }
}