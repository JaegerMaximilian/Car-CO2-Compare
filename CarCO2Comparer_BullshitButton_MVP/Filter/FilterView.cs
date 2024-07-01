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
using CarCO2Comparer_BullshitButton_MVP.Exceptions;

namespace CarCO2Comparer_BullshitButton_MVP.Filter
{
    public partial class FilterView : Form, IFilterView
    {
        #region Events
        public event EventHandler<CarFilter> SaveClicked;
        public event EventHandler ResetClicked;
        #endregion

        #region Members
        public CarFilter CarFilter { get; set; }
        #endregion

        #region Constructor
        public FilterView()
        {
            InitializeComponent();
            CarFilter = new CarFilter();

            // Hide Error Labels
            label_EngineSizeError.Hide();
            label_CylindersError.Hide();
            label_FuelConsumptionError.Hide();
            label_CO2EmissionsError.Hide();

            SetTextComboBoxesToDefault();
            txtBox_Brand1.Text = "Audi";
            txtBox_Brand2.Text = "BMW";
            txtBox_Model1.Text = "A4";
            txtBox_Model2.Text = "335i";
        }
        #endregion

        #region StartUp Methods

        // sets all filter possibilities to a default value
        private void SetTextComboBoxesToDefault()
        {
            // Set TextBoxes to Default
            txtBox_Brand1.Text = "-";
            txtBox_Model1.Text = "-";
            txtBox_Brand2.Text = "-";
            txtBox_Model2.Text = "-";
            txtBox_EngineSizeMin.Text = "-";
            txtBox_EngineSizeMax.Text = "-";
            txtBox_CylindersMin.Text = "-";
            txtBox_CylindersMax.Text = "-";
            txtBox_FuelConsumptionMin.Text = "-";
            txtBox_FuelConsumptionMax.Text = "-";
            txtBox_CO2EmissionsMin.Text = "-";
            txtBox_CO2EmissionsMax.Text = "-";

            // Connect Comboboxes to Enums
            var EnumListVehicleClass = new List<string>();
            foreach (var item in Enum.GetValues(typeof(VehicleClass)))
            {
                EnumListVehicleClass.Add(EnumDescriptionHandler.GetEnumDescription(item));
            }
            combBox_VehicleClass.DataSource = EnumListVehicleClass;

            var EnumListTransmission = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Transmission)))
            {
                EnumListTransmission.Add(EnumDescriptionHandler.GetEnumDescription(item));
            }
            combBox_Transmission.DataSource = EnumListTransmission;

            var EnumListFuelType = new List<string>();
            foreach (var item in Enum.GetValues(typeof(FuelType)))
            {
                EnumListFuelType.Add(EnumDescriptionHandler.GetEnumDescription(item));
            }
            combBox_FuelType.DataSource = EnumListFuelType;
        }
        #endregion

        #region Methods

        // sends event with the parameter of the FilterSettings to Save them in FilterPresenter
        private void btn_Save_Click(object sender, EventArgs e)
        {
            bool succesfull = false;

            CarFilter filtersettings = GetFilterSettings(out succesfull);

            if (succesfull) 
            {
                this.Hide();
                SaveClicked?.Invoke(this, GetFilterSettings(out bool successful));
            }
        }
        private void FilterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // Set Text and ComboBoxes to Default
            SetTextComboBoxesToDefault();

            // Set Backcolor to Default
            GetFilterSettingsFromTextBoxes();

            ResetClicked?.Invoke(this, e);
        }

        // takes all filter settings from the boxes in View and returns them in a CarFilter object
        private CarFilter GetFilterSettings(out bool convertSuccesfull)
        {
            List<bool> convert = new List<bool>();
            CarFilter = new CarFilter();
            convertSuccesfull = true;

            // Get Strings from TextBoxes and remove Whitespaces
            CarFilter.Brand[0] = txtBox_Brand1.Text.Trim(' ');
            CarFilter.Brand[1] = txtBox_Brand2.Text.Trim(' ');
            CarFilter.Model[0] = txtBox_Model1.Text.Trim(' ');
            CarFilter.Model[1] = txtBox_Model2.Text.Trim(' ');

            // Get Enums from ComboBoxes
            CarFilter.VehicleClass = (VehicleClass)combBox_VehicleClass.SelectedIndex;
            CarFilter.Transmission = (Transmission)combBox_Transmission.SelectedIndex;
            CarFilter.FuelType = (FuelType)combBox_FuelType.SelectedIndex;

            // Get Filtersettings from TextBoxes
            convert = GetFilterSettingsFromTextBoxes();

            // If parsing worked set convertSuccesfull to True
            if (convert.Contains(false)) convertSuccesfull = false;
            return CarFilter;

            
        }
        private List<bool> GetFilterSettingsFromTextBoxes()
        {
            List<bool> parsingSuccesfull = new List<bool>();

            #region EngineSizeMin
            bool engineSizeError = false;
            try
            {
                // Try to Parse with own Method
                CarFilter.EngineSizeMin = decimalParse(txtBox_EngineSizeMin.Text);

                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_EngineSizeMin.BackColor = Color.White;
                label_EngineSizeError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_EngineSizeMin.BackColor = Color.Red;
                label_EngineSizeError.Text = "Value below Zero!";
                label_EngineSizeError.Show();
                parsingSuccesfull.Add(false);
                engineSizeError = true;
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_EngineSizeMin.BackColor = Color.Red;
                label_EngineSizeError.Text = "Not a Number!";
                label_EngineSizeError.Show();
                parsingSuccesfull.Add(false);
                engineSizeError = true;
            }
            #endregion
            #region EngineSizeMax
            try
            {
                // Try to Parse with own Method
                CarFilter.EngineSizeMax = decimalParse(txtBox_EngineSizeMax.Text);
                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_EngineSizeMax.BackColor = Color.White;
                if (!engineSizeError) label_EngineSizeError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_EngineSizeMax.BackColor = Color.Red;
                label_EngineSizeError.Text = "Value below Zero!";
                label_EngineSizeError.Show();
                parsingSuccesfull.Add(false);
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_EngineSizeMax.BackColor = Color.Red;
                label_EngineSizeError.Text = "Not a Number!";
                label_EngineSizeError.Show();
                parsingSuccesfull.Add(false);
            }
            #endregion
            #region CylindersMin
            bool cylindersError = false;
            try
            {
                // Try to Parse with own Method
                CarFilter.CylindersMin = intParse(txtBox_CylindersMin.Text);
                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_CylindersMin.BackColor = Color.White;
                label_CylindersError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_CylindersMin.BackColor = Color.Red;
                label_CylindersError.Text = "Value below Zero!";
                label_CylindersError.Show();
                parsingSuccesfull.Add(false);
                cylindersError = true;
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_CylindersMin.BackColor = Color.Red;
                label_CylindersError.Text = "Not a Number!";
                label_CylindersError.Show();
                parsingSuccesfull.Add(false);
                cylindersError = true;
            }
            #endregion
            #region CylindersMax
            try
            {
                // Try to Parse with own Method
                CarFilter.CylindersMax = intParse(txtBox_CylindersMax.Text);
                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_CylindersMax.BackColor = Color.White;
                if (!cylindersError) label_CylindersError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_CylindersMax.BackColor = Color.Red;
                label_CylindersError.Text = "Value below Zero!";
                label_CylindersError.Show();
                parsingSuccesfull.Add(false);
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_CylindersMax.BackColor = Color.Red;
                label_CylindersError.Text = "Not a Number!";
                label_CylindersError.Show();
                parsingSuccesfull.Add(false);
            }
            #endregion
            #region FuelConsumptionMin
            bool fuelConsumptionError = false;
            try
            {
                // Try to Parse with own Method
                CarFilter.FuelConsumptionMin = decimalParse(txtBox_FuelConsumptionMin.Text);

                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_FuelConsumptionMin.BackColor = Color.White;
                label_FuelConsumptionError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_FuelConsumptionMin.BackColor = Color.Red;
                label_FuelConsumptionError.Text = "Value below Zero!";
                label_FuelConsumptionError.Show();
                parsingSuccesfull.Add(false);
                fuelConsumptionError = true;
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_FuelConsumptionMin.BackColor = Color.Red;
                label_FuelConsumptionError.Text = "Not a Number!";
                label_FuelConsumptionError.Show();
                parsingSuccesfull.Add(false);
                fuelConsumptionError = true;
            }
            #endregion
            #region FuelConsumptionMax
            try
            {
                // Try to Parse with own Method
                CarFilter.FuelConsumptionMax = decimalParse(txtBox_FuelConsumptionMax.Text);

                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_FuelConsumptionMax.BackColor = Color.White;
                if (!fuelConsumptionError) label_FuelConsumptionError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_FuelConsumptionMax.BackColor = Color.Red;
                label_FuelConsumptionError.Text = "Value below Zero!";
                label_FuelConsumptionError.Show();
                parsingSuccesfull.Add(false);
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_FuelConsumptionMax.BackColor = Color.Red;
                label_FuelConsumptionError.Text = "Not a Number!";
                label_FuelConsumptionError.Show();
                parsingSuccesfull.Add(false);
            }
            #endregion
            #region CO2EmissionsMin
            bool co2EmissionsError = false;
            try
            {
                // Try to Parse with own Method
                CarFilter.CO2EmissionsMin = decimalParse(txtBox_CO2EmissionsMin.Text);

                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_CO2EmissionsMin.BackColor = Color.White;
                label_CO2EmissionsError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_CO2EmissionsMin.BackColor = Color.Red;
                label_CO2EmissionsError.Text = "Value below Zero!";
                label_CO2EmissionsError.Show();
                parsingSuccesfull.Add(false);
                co2EmissionsError = true;
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_CO2EmissionsMin.BackColor = Color.Red;
                label_CO2EmissionsError.Text = "Not a Number!";
                label_CO2EmissionsError.Show();
                parsingSuccesfull.Add(false);
                co2EmissionsError = true;
            }
            #endregion
            #region CO2EmissionsMax
            try
            {
                // Try to Parse with own Method
                CarFilter.CO2EmissionsMax = decimalParse(txtBox_CO2EmissionsMax.Text);

                // Set TextBox to default and Hide Errorlabel, if previosly an Error occured
                txtBox_CO2EmissionsMax.BackColor = Color.White;
                if (!co2EmissionsError) label_CO2EmissionsError.Hide();
                parsingSuccesfull.Add(true);
            }
            catch (ValueBelowZeroException)
            {
                // If ValueBelowZeroException occured show Error (Value Below Zero)
                txtBox_CO2EmissionsMax.BackColor = Color.Red;
                label_CO2EmissionsError.Text = "Value below Zero!";
                label_CO2EmissionsError.Show();
                parsingSuccesfull.Add(false);
            }
            catch
            {
                // If any other Exception occured show Error (Not a Number)
                txtBox_CO2EmissionsMax.BackColor = Color.Red;
                label_CO2EmissionsError.Text = "Not a Number!";
                label_CO2EmissionsError.Show();
                parsingSuccesfull.Add(false);
            }
            #endregion

            return parsingSuccesfull;
        }
        #endregion

        #region Parse Methods
        private decimal decimalParse(string text)
        {
            // Remove whitespaces if there are any
            text = text.Trim(' ');
            decimal number;

            // if text is default set number to own defined default
            if (text == "-" || text == "")
            {
                number = -1;
            }

            else
            {
                number = decimal.Parse(text.Replace('.', ','));

                // if number is < 0 throw ValuBelowZeroException
                if (number < 0) throw new ValueBelowZeroException();
            }
            return number;
        }
        private int intParse(string text)
        {
            // Remove whitespaces if there are any
            text = text.Trim(' ');
            int number;

            // if text is default set number to own defined default
            if (text == "-" || text == "")
            {
                number = -1;
            }

            else
            {
                number = int.Parse(text);

                // if number is < 0 throw ValuBelowZeroException
                if (number < 0) throw new ValueBelowZeroException();
            }
            return number;
        }
        #endregion
    }
}
