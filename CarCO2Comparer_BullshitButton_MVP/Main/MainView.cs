using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP.Enums;
using  CarCO2Comparer_BullshitButton_MVP.Filter;
//nur zum Testen!!
//using CarCO2Comparer_BullshitButton_MVP.FileHandler;

namespace CarCO2Comparer_BullshitButton_MVP
{
    public partial class MainView : Form, IMainView
    {
        #region Events
        public event EventHandler FilterViewRequested;
        public event EventHandler GraphViewRequested;
        public event EventHandler JokeRequested;
        public event EventHandler LoadFileRequested;
        #endregion

        #region Constructor
        public MainView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void toolStripMenuItem_Load_Click(object sender, EventArgs e)
        {
            
            LoadFileRequested?.Invoke(this, e);
        }

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_SeriousButton_Click(object sender, EventArgs e)
        {
            JokeRequested?.Invoke(this, e);
        }
        
        private void toolStripMenuItem_Filter_Click(object sender, EventArgs e)
        {
            FilterViewRequested?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private void toolStripMenuItem_BarChart_Click(object sender, EventArgs e)
        {
            GraphViewRequested?.Invoke(this, EventArgs.Empty);
        }

        
        public void LoadDataInList(List<Car> carlist)
        {
            // First remove all items
            listView.Items.Clear();
           
            
            // then adds all cars you want to add
            int i = 0;
            foreach (var car in carlist)
            {
                ListViewItem item = new ListViewItem(car.Brand.ToString(), i);
                item.SubItems.Add(car.Model.ToString());
                item.SubItems.Add(EnumDescriptionHandler.GetEnumDescription(car.vehicleClass));
                item.SubItems.Add(car.EngineSize.ToString());
                item.SubItems.Add(car.Zylinder.ToString());
                item.SubItems.Add(EnumDescriptionHandler.GetEnumDescription(car.transmission));
                item.SubItems.Add(EnumDescriptionHandler.GetEnumDescription(car.fuelType));
                item.SubItems.Add(car.FuelConsumptionCombined.ToString());
                item.SubItems.Add(car.CO2Emission.ToString());
                i++;

                

                listView.Items.Add(item);
            }
        }

        public void ShowFilterSettings(CarFilter carFilter)
        {
            listFilterOptions.Items.Clear();

            // Show that this are FilterOptions
            listFilterOptions.Items.Add("Filteroptions:");
            listFilterOptions.Items.Add("");
            // Show filtered Brands
            listFilterOptions.Items.Add($"Brand:\t\t{carFilter.Brand[0]}\t{carFilter.Brand[1]}");
            // Show filtered Models
            listFilterOptions.Items.Add($"Model:\t\t{carFilter.Model[0]}\t{carFilter.Model[1]}");

            listFilterOptions.Items.Add("");

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

        public void SetCurrentFile(string filePath)
        {
            filepath.Text = filePath;
        }


    }
}
