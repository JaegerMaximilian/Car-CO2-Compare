using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCO2Comparer_BullshitButton_MVP.Enums
{
    public static class EnumDescriptionHandler
    {
        // EnumDescriptionHandler for a pretty GUI
        public static string GetEnumDescription<T>(T enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttribute = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }
    }

    public enum VehicleClass
    {
        [Description("None")]
        NONE,
        [Description("Compact")]
        COMPACT,
        [Description("Minicompact")]
        MINICOMPACT,
        [Description("Subcompact")]
        SUBCOMPACT,
        [Description("SUV small")]
        SUV_SMALL,
        [Description("SUV standard")]
        SUV_STANDARD,
        [Description("Midsize")]
        MID_SIZE,
        [Description("Fullsize")]
        FULL_SIZE,
        [Description("Two-Seater")]
        TWO_SEATER,
        [Description("Station Wagon small")]
        STATION_WAGON_SMALL,
        [Description("Station Wagon midsize")]
        STATION_WAGON_MID_SIZE,
        [Description("Van Cargo")]
        VAN_CARGO,
        [Description("Van Passenger")]
        VAN_PASSENGER,
        [Description("Minivan")]
        MINIVAN,
        [Description("Pickup-Truck small")]
        PICKUP_TRUCK_SMALL,
        [Description("Pickup-Truck Standard")]
        PICKUP_TRUCK_STANDARD,
        [Description("Special purpose Vehicle")]
        SPECIAL_PURPOSE_VEHICLE
    }

    public enum Transmission
    {
        [Description("None")]
        NONE,
        [Description("Automatic")]
        A_Automatic,
        [Description("Automated manual")]
        AM_Automated_manual,
        [Description("Automatic with selected shift")]
        AS_Automatic_with_select_shift,
        [Description("Continuously variable")]
        AV_Continuously_variable,
        [Description("All Manual")]
        M_All,
        [Description("Manual 3 Gears")]
        M3,
        [Description("Manual 4 Gears")]
        M4,
        [Description("Manual 5 Gears")]
        M5,
        [Description("Manual 6 Gears")]
        M6,
        [Description("Manual 7 Gears")]
        M7,
        [Description("Manual 8 Gears")]
        M8,
        [Description("Manual 9 Gears")]
        M9,
        [Description("Manual 10 Gears")]
        M10
    }

    public enum FuelType
    {
        [Description("None")]
        None,
        [Description("Regular Gasoline")]
        X_Regular_gasoline,
        [Description("Premium Gasoline")]
        Z_Premium_gasoline,
        [Description("Diesel")]
        D_Diesel,
        [Description("Ethanol E85")]
        E_Ethanol_E85,
        [Description("Natural Gas")]
        N_Natural_gas
    }

    public enum BarChartOption
    {
        [Description("Engine Size")]
        EnigneSize,
        [Description("Cylinders")]
        Cylinders,
        [Description("Fuel Consumption")]
        FuelConsumption,
        [Description("CO2 Emissions")]
        CO2Emissions
    }
}
