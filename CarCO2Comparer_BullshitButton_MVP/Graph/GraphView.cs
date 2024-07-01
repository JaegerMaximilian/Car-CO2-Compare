using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP.Filter;
using CarCO2Comparer_BullshitButton_MVP.Enums;

namespace CarCO2Comparer_BullshitButton_MVP.Graph
{
    public partial class GraphView : Form, IGraphView
    {
        #region Events
        public event EventHandler JokeRequested;
        #endregion

        #region Members
        private List<Car> _filteredCars { get; set; }
        public CarFilter carFilter { get; set; }
        #endregion

        #region Constructor
        public GraphView()
        {
            InitializeComponent();

            label_Hint.Hide();
            carFilter = new CarFilter();
            _filteredCars = new List<Car>();
            SetComboBoxBarchartOptions();
            ShowFilterSettings();
        }
        #endregion

        #region StartUp Methods
        private void SetComboBoxBarchartOptions()
        {
            var EnumListBarChartOptions = new List<string>();
            foreach (var item in Enum.GetValues(typeof(BarChartOption)))
            {
                EnumListBarChartOptions.Add(EnumDescriptionHandler.GetEnumDescription(item));
            }
            comboBox_BarChartOption.DataSource = EnumListBarChartOptions;
        }
        #endregion

        #region Methods
        private void SetGraph()
        {
            cartesianChart.AxisY.Clear();
            cartesianChart.AxisX.Clear();

            // Get Values for Chart
            ChartValues<decimal> chartValues = new ChartValues<decimal>();

            switch ((BarChartOption)comboBox_BarChartOption.SelectedIndex)
            {
                case BarChartOption.EnigneSize:
                    
                    foreach (var item in _filteredCars)
                    {
                        chartValues.Add(item.EngineSize);
                    }
                    break;

                case BarChartOption.Cylinders:

                    foreach (var item in _filteredCars)
                    {
                        chartValues.Add(item.Zylinder);
                    }
                    break;

                case BarChartOption.FuelConsumption:

                    foreach (var item in _filteredCars)
                    {
                        chartValues.Add(item.FuelConsumptionCombined);
                    }
                    break;

                case BarChartOption.CO2Emissions:

                    
                    foreach (var item in _filteredCars)
                    {
                        chartValues.Add(item.CO2Emission);
                    }
                    break;
            }

            // Set Values in new Chart Series
            cartesianChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = chartValues
                }
            };

            // Get Lables for X Axis
            string[] labels = new string[_filteredCars.Count];

            for(int i = 0; i < _filteredCars.Count; i++)
            {
                labels[i] = _filteredCars[i].Brand + "\n" + _filteredCars[i].Model;
            }

            // Set Lables for X Axis
            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Cars",
                Labels = labels
            });

            // Set Lables for y Axis
            cartesianChart.AxisY.Add(new Axis
            {
                Title = EnumDescriptionHandler.GetEnumDescription((BarChartOption)comboBox_BarChartOption.SelectedIndex),
                LabelFormatter = value => value.ToString("N")
            });

            // Set Zooming to X Axis
            cartesianChart.Zoom = ZoomingOptions.X;
        }

        private void btn_SeriousButton_Click(object sender, EventArgs e)
        {
            JokeRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Create SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "png (*.png)|*.png";

            // Start Dialog and if Result is Ok Save as png
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(cartesianChart.Width, cartesianChart.Height);
                cartesianChart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        public void ShowFilterSettings()
        {
            listFilterOptions.Items.Clear();

            // Show that this are FilterOptions
            listFilterOptions.Items.Add("Filteroptions:");
            // Show filtered Brands
            listFilterOptions.Items.Add($"Brand:\t\t{carFilter.Brand[0]}\t{carFilter.Brand[1]}");
            // Show filtered Models
            listFilterOptions.Items.Add($"Model:\t\t{carFilter.Model[0]}\t{carFilter.Model[1]}");
            // Show filtered Vehicle-Class
            listFilterOptions.Items.Add($"Vehicle Class:\t\t{EnumDescriptionHandler.GetEnumDescription(carFilter.VehicleClass)}");

            // Show filtered Engine-Size
            if (carFilter.EngineSizeMin < 0 && carFilter.EngineSizeMax < 0)
            {
                listFilterOptions.Items.Add($"Engine Size / L:\t\tNone");
            }
            else if (carFilter.EngineSizeMin < 0 && carFilter.EngineSizeMax > 0)
            {
                listFilterOptions.Items.Add($"Engine Size / L:\t\t0 - {carFilter.EngineSizeMax}");
            }
            else if (carFilter.EngineSizeMin > 0 && carFilter.EngineSizeMax < 0)
            {
                listFilterOptions.Items.Add($"Engine Size / L:\t\t{carFilter.EngineSizeMin} - to");
            }
            else
            {
                listFilterOptions.Items.Add($"Engine Size / L:\t\t{carFilter.EngineSizeMin} - {carFilter.EngineSizeMax}");
            }

            // Show filtered Cylinders
            if (carFilter.CylindersMin < 0 && carFilter.CylindersMax < 0)
            {
                listFilterOptions.Items.Add($"Cylinders:\t\t\tNone");
            }
            else if (carFilter.CylindersMin < 0 && carFilter.CylindersMax > 0)
            {
                listFilterOptions.Items.Add($"Cylinders:\t\t\t0 - {carFilter.CylindersMax}");
            }
            else if (carFilter.CylindersMin > 0 && carFilter.CylindersMax < 0)
            {
                listFilterOptions.Items.Add($"Cylinders:\t\t\t{carFilter.CylindersMin} - to");
            }
            else
            {
                listFilterOptions.Items.Add($"Cylinders:\t\t\t{carFilter.CylindersMin} - {carFilter.CylindersMax}");
            }

            // Show filtered Transmission
            listFilterOptions.Items.Add($"Transmission:\t\t{EnumDescriptionHandler.GetEnumDescription(carFilter.Transmission)}");
            // Show filtered Fuel Type
            listFilterOptions.Items.Add($"Fuel Type:\t\t{EnumDescriptionHandler.GetEnumDescription(carFilter.FuelType)}");

            // Show filtered CO2 Emissions
            if (carFilter.CO2EmissionsMin < 0 && carFilter.CO2EmissionsMax < 0)
            {
                listFilterOptions.Items.Add($"CO2 Emmissions / mg:\tNone");
            }
            else if (carFilter.CO2EmissionsMin < 0 && carFilter.CO2EmissionsMax > 0)
            {
                listFilterOptions.Items.Add($"CO2 Emmissions / mg:\t0 - {carFilter.CO2EmissionsMax}");
            }
            else if (carFilter.CO2EmissionsMin > 0 && carFilter.CO2EmissionsMax < 0)
            {
                listFilterOptions.Items.Add($"CO2 Emmissions / mg:\t{carFilter.CO2EmissionsMax} - to");
            }
            else
            {
                listFilterOptions.Items.Add($"CO2 Emmissions / mg:\t{carFilter.CO2EmissionsMin} - {carFilter.CO2EmissionsMax}");
            }
        }

        private void comboBox_BarChartOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_filteredCars.Count != 0)
            {
                SetGraph();
            }
        }

        private void GraphView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void SetFilteredCars(List<Car> filteredCars)
        {
            _filteredCars.Clear();
            _filteredCars = filteredCars;

            if (_filteredCars.Count > 0 && _filteredCars.Count <= 40)
            {
                SetGraph();
                label_Hint.Hide();
            }
            else if (_filteredCars.Count <= 0)
            {
                label_Hint.Text = "No Cars available to show!";
                label_Hint.Show();
            }
            else if (_filteredCars.Count > 40)
            {
                label_Hint.Text = "Too many Cars to show Graph. Select less than 40!";
                label_Hint.Show();
            }
        }
        #endregion
    }
}
