using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Enums;

namespace CarCO2Comparer_BullshitButton_MVP.Filter
{
    public class CarFilter
    {
        #region Properties
        public string[] Brand { get; set; }
        public string[] Model { get; set; }
        public VehicleClass VehicleClass { get; set; }
        public decimal EngineSizeMin { get; set; }
        public decimal EngineSizeMax { get; set; }
        public int CylindersMin { get; set; }
        public int CylindersMax { get; set; }
        public Transmission Transmission { get; set; }
        public FuelType FuelType { get; set; }
        public decimal FuelConsumptionMin { get; set; }
        public decimal FuelConsumptionMax { get; set; }
        public decimal CO2EmissionsMin { get; set; }
        public decimal CO2EmissionsMax { get; set; }
        #endregion

        #region Constructor
        public CarFilter()
        {
            // Set to default Filteroptions
            Brand = new string[2];
            Model = new string[2];
            VehicleClass = VehicleClass.NONE;
            EngineSizeMin = -1;
            EngineSizeMax = -1;
            CylindersMin = -1;
            CylindersMax = -1;
            Transmission = Transmission.NONE;
            FuelType = FuelType.None;
            FuelConsumptionMin = -1;
            FuelConsumptionMax = -1;
            CO2EmissionsMin = -1;
            CO2EmissionsMax = -1;
        }
        #endregion
    }
}
