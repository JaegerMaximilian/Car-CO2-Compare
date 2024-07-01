namespace CarCO2Comparer_BullshitButton_MVP
{
    partial class MainView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Filter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_BarChart = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_CurrentFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_SetCurrentFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnMarke = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVehicleClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEngineSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCylinders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTransmission = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFuelType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFuelConsumption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCO2Emissions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_SeriousButton = new System.Windows.Forms.Button();
            this.listFilterOptions = new System.Windows.Forms.ListBox();
            this.filepath = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1283, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Load,
            this.toolStripMenuItem_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem_Load
            // 
            this.toolStripMenuItem_Load.Name = "toolStripMenuItem_Load";
            this.toolStripMenuItem_Load.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_Load.Text = "Load";
            this.toolStripMenuItem_Load.Click += new System.EventHandler(this.toolStripMenuItem_Load_Click);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_Exit.Text = "Exit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Filter,
            this.toolStripMenuItem_BarChart});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripMenuItem_Filter
            // 
            this.toolStripMenuItem_Filter.Name = "toolStripMenuItem_Filter";
            this.toolStripMenuItem_Filter.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Filter.Text = "Filter";
            this.toolStripMenuItem_Filter.Click += new System.EventHandler(this.toolStripMenuItem_Filter_Click);
            // 
            // toolStripMenuItem_BarChart
            // 
            this.toolStripMenuItem_BarChart.Name = "toolStripMenuItem_BarChart";
            this.toolStripMenuItem_BarChart.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_BarChart.Text = "Bar Chart";
            this.toolStripMenuItem_BarChart.Click += new System.EventHandler(this.toolStripMenuItem_BarChart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_CurrentFile,
            this.toolStripStatusLabel_SetCurrentFile,
            this.filepath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1283, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_CurrentFile
            // 
            this.toolStripStatusLabel_CurrentFile.Name = "toolStripStatusLabel_CurrentFile";
            this.toolStripStatusLabel_CurrentFile.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel_CurrentFile.Text = "Current File:";
            // 
            // toolStripStatusLabel_SetCurrentFile
            // 
            this.toolStripStatusLabel_SetCurrentFile.Name = "toolStripStatusLabel_SetCurrentFile";
            this.toolStripStatusLabel_SetCurrentFile.Size = new System.Drawing.Size(0, 17);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMarke,
            this.columnModel,
            this.columnVehicleClass,
            this.columnEngineSize,
            this.columnCylinders,
            this.columnTransmission,
            this.columnFuelType,
            this.columnFuelConsumption,
            this.columnCO2Emissions});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 28);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(994, 452);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnMarke
            // 
            this.columnMarke.Text = "Brand";
            this.columnMarke.Width = 150;
            // 
            // columnModel
            // 
            this.columnModel.Text = "Model";
            this.columnModel.Width = 150;
            // 
            // columnVehicleClass
            // 
            this.columnVehicleClass.Text = "VehicleClass";
            this.columnVehicleClass.Width = 100;
            // 
            // columnEngineSize
            // 
            this.columnEngineSize.Text = "Engine Size / L";
            this.columnEngineSize.Width = 90;
            // 
            // columnCylinders
            // 
            this.columnCylinders.Text = "Cylinders";
            this.columnCylinders.Width = 55;
            // 
            // columnTransmission
            // 
            this.columnTransmission.Text = "Transmission";
            this.columnTransmission.Width = 90;
            // 
            // columnFuelType
            // 
            this.columnFuelType.Text = "Fuel Type";
            // 
            // columnFuelConsumption
            // 
            this.columnFuelConsumption.Text = "Fuel Consumption / L/100km";
            this.columnFuelConsumption.Width = 150;
            // 
            // columnCO2Emissions
            // 
            this.columnCO2Emissions.Text = "CO2 Emissions / g/100km";
            this.columnCO2Emissions.Width = 150;
            // 
            // btn_SeriousButton
            // 
            this.btn_SeriousButton.BackColor = System.Drawing.Color.Red;
            this.btn_SeriousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SeriousButton.Location = new System.Drawing.Point(1000, 430);
            this.btn_SeriousButton.Name = "btn_SeriousButton";
            this.btn_SeriousButton.Size = new System.Drawing.Size(281, 50);
            this.btn_SeriousButton.TabIndex = 3;
            this.btn_SeriousButton.Text = "Super Serious Button";
            this.btn_SeriousButton.UseVisualStyleBackColor = false;
            this.btn_SeriousButton.Click += new System.EventHandler(this.btn_SeriousButton_Click);
            // 
            // listFilterOptions
            // 
            this.listFilterOptions.BackColor = System.Drawing.SystemColors.Control;
            this.listFilterOptions.FormattingEnabled = true;
            this.listFilterOptions.Location = new System.Drawing.Point(997, 28);
            this.listFilterOptions.Margin = new System.Windows.Forms.Padding(0);
            this.listFilterOptions.Name = "listFilterOptions";
            this.listFilterOptions.Size = new System.Drawing.Size(281, 394);
            this.listFilterOptions.TabIndex = 6;
            // 
            // filepath
            // 
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(0, 17);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 505);
            this.Controls.Add(this.listFilterOptions);
            this.Controls.Add(this.btn_SeriousButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Caremissions Comparer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_CurrentFile;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_SetCurrentFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Load;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Filter;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnMarke;
        private System.Windows.Forms.ColumnHeader columnModel;
        private System.Windows.Forms.ColumnHeader columnVehicleClass;
        private System.Windows.Forms.ColumnHeader columnEngineSize;
        private System.Windows.Forms.ColumnHeader columnCylinders;
        private System.Windows.Forms.ColumnHeader columnTransmission;
        private System.Windows.Forms.ColumnHeader columnFuelType;
        private System.Windows.Forms.ColumnHeader columnFuelConsumption;
        private System.Windows.Forms.ColumnHeader columnCO2Emissions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_BarChart;
        private System.Windows.Forms.Button btn_SeriousButton;
        private System.Windows.Forms.ListBox listFilterOptions;
        private System.Windows.Forms.ToolStripStatusLabel filepath;
    }
}

