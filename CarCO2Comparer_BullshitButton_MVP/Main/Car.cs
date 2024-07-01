using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Enums;

namespace CarCO2Comparer_BullshitButton_MVP
{
    public class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public VehicleClass vehicleClass  { get; private set; }
        public decimal EngineSize { get; private set; }
        public int Zylinder { get; private set; }
        public Transmission transmission {get;private set; }
        public FuelType fuelType{get; private set; }
        public decimal FuelConsumptionCombined { get; private set; }
        public decimal CO2Emission { get; private set; }


        public Car(string brand,
                   string model,
                   VehicleClass vehicleclass,
                   decimal engineszize,
                   int zylinder,
                   Transmission transmission,
                   FuelType fueltype,
                   decimal fuelconsumptioncombined,
                   decimal co2emission)
        {
            Brand = brand;
            Model = model;
            vehicleClass = vehicleclass;
            EngineSize = engineszize;
            Zylinder = zylinder;
            EngineSize = engineszize;
            Zylinder = zylinder;
            this.transmission = transmission;
            fuelType = fueltype;
            FuelConsumptionCombined = fuelconsumptioncombined;
            CO2Emission = co2emission;
        }
    
        

    }
}
