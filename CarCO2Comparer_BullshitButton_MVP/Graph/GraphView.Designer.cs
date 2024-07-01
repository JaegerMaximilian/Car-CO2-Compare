using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;

namespace CarCO2Comparer_BullshitButton_MVP.Graph
{
    partial class GraphView
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
            this.comboBox_BarChartOption = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_SeriousButton = new System.Windows.Forms.Button();
            this.listFilterOptions = new System.Windows.Forms.ListBox();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.label_Hint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_BarChartOption
            // 
            this.comboBox_BarChartOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BarChartOption.FormattingEnabled = true;
            this.comboBox_BarChartOption.Location = new System.Drawing.Point(761, 12);
            this.comboBox_BarChartOption.Name = "comboBox_BarChartOption";
            this.comboBox_BarChartOption.Size = new System.Drawing.Size(281, 21);
            this.comboBox_BarChartOption.TabIndex = 1;
            this.comboBox_BarChartOption.SelectedIndexChanged += new System.EventHandler(this.comboBox_BarChartOption_SelectedIndexChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(761, 465);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 32);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_SeriousButton
            // 
            this.btn_SeriousButton.BackColor = System.Drawing.Color.Red;
            this.btn_SeriousButton.Location = new System.Drawing.Point(842, 465);
            this.btn_SeriousButton.Name = "btn_SeriousButton";
            this.btn_SeriousButton.Size = new System.Drawing.Size(200, 32);
            this.btn_SeriousButton.TabIndex = 4;
            this.btn_SeriousButton.Text = "Just a Serious Button";
            this.btn_SeriousButton.UseVisualStyleBackColor = false;
            this.btn_SeriousButton.Click += new System.EventHandler(this.btn_SeriousButton_Click);
            // 
            // listFilterOptions
            // 
            this.listFilterOptions.BackColor = System.Drawing.SystemColors.Control;
            this.listFilterOptions.FormattingEnabled = true;
            this.listFilterOptions.Location = new System.Drawing.Point(761, 36);
            this.listFilterOptions.Margin = new System.Windows.Forms.Padding(0);
            this.listFilterOptions.Name = "listFilterOptions";
            this.listFilterOptions.Size = new System.Drawing.Size(281, 420);
            this.listFilterOptions.TabIndex = 5;
            // 
            // cartesianChart
            // 
            this.cartesianChart.Location = new System.Drawing.Point(12, 12);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(743, 484);
            this.cartesianChart.TabIndex = 6;
            this.cartesianChart.Text = "cartesianChart1";
            // 
            // label_Hint
            // 
            this.label_Hint.AutoSize = true;
            this.label_Hint.ForeColor = System.Drawing.Color.Red;
            this.label_Hint.Location = new System.Drawing.Point(762, 442);
            this.label_Hint.Name = "label_Hint";
            this.label_Hint.Size = new System.Drawing.Size(35, 13);
            this.label_Hint.TabIndex = 7;
            this.label_Hint.Text = "label1";
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 508);
            this.Controls.Add(this.label_Hint);
            this.Controls.Add(this.cartesianChart);
            this.Controls.Add(this.listFilterOptions);
            this.Controls.Add(this.btn_SeriousButton);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.comboBox_BarChartOption);
            this.Name = "GraphView";
            this.Text = "Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_BarChartOption;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_SeriousButton;
        private System.Windows.Forms.ListBox listFilterOptions;
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        private System.Windows.Forms.Label label_Hint;
    }
}