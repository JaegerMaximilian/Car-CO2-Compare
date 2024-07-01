using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP.Main;
using CarCO2Comparer_BullshitButton_MVP.Enums;

// for language detection, if the use comma seperated or , seperated
using System.Globalization;


namespace CarCO2Comparer_BullshitButton_MVP.FileHandler
{
    public class FilePersistor : IFilePersistor
    {
        public event EventHandler<string> FilePathChanged;

        // get FilePath from the OpenFileDialog Menu and return string FilePath
        public string GetFilePath()
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = $"{AppDomain.CurrentDomain.BaseDirectory} ..\..\..\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                // Hob i gach geändert das ma ned dauernd suchen muss
                openFileDialog.InitialDirectory = @"..\..\..\..\Files";
                //openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    FilePathChanged?.Invoke(this, filePath);
                    //Read the contents
                }

            }
            return filePath;
        }


        // take FilePath and turn the CSV into a CarList object
        public CarList CarListFromCSV(string filePath)
        {

            List<Car> carlist = new List<Car>();
            
                    //for language detection
                    CultureInfo cultureInfo = CultureInfo.InstalledUICulture;

                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        sr.ReadLine(); //to get rid of header 
                        while (sr.EndOfStream == false)
                        {
                          
                            string Line = sr.ReadLine();
                            string[] Data = Line.Split(',');

                            //int.TryParse(Data[0], out int temp_id);
                            //string temp_name = Data[1];
                            //int.TryParse(Data[2], out int temp_anzahl);

                            
                            int zylinder = 0;
                            decimal enginesize = 0;
                            decimal fuelconsumptioncombined = 0;
                            decimal co2Emission = 0;

                            string brand = Data[0];
                            string model = Data[1];
                            // enum switch vehicleclass
                            VehicleClass vehicleclass = VehicleClass.NONE;
                            switch (Data[2])
                            {
                                // nicht name von enum sondern wie in csv beschrieben (mit Leerzeichen und Co)
                                case "COMPACT"://falsch
                                    vehicleclass = VehicleClass.COMPACT;
                                    break;
                                case "MINICOMPACT":
                                    vehicleclass = VehicleClass.MINICOMPACT;
                                    break;
                                case "SUBCOMPACT":
                                    vehicleclass = VehicleClass.SUBCOMPACT;
                                    break;
                                case "SUV - SMALL":
                                    vehicleclass = VehicleClass.SUV_SMALL;
                                    break;
                                case "SUV - STANDARD":
                                    vehicleclass = VehicleClass.SUV_STANDARD;
                                    break;
                                case "MID-SIZE":
                                    vehicleclass = VehicleClass.MID_SIZE;
                                    break;
                                case "FULL-SIZE":
                                    vehicleclass = VehicleClass.FULL_SIZE;
                                    break;
                                case "TWO-SEATER":
                                    vehicleclass = VehicleClass.TWO_SEATER;
                                    break;
                                case "STATION WAGON - SMALL":
                                    vehicleclass = VehicleClass.STATION_WAGON_SMALL;
                                    break;
                                case "STATION_WAGON_MID_SIZE": // nicht
                                    vehicleclass = VehicleClass.STATION_WAGON_MID_SIZE;
                                    break;
                                case "VAN_CARGO": //passt noch nicht
                                    vehicleclass = VehicleClass.VAN_CARGO;
                                    break;
                                case "VAN - PASSENGER":
                                    vehicleclass = VehicleClass.VAN_PASSENGER;
                                    break;
                                case "MINIVAN":
                                    vehicleclass = VehicleClass.MINIVAN;
                                    break;
                                case "PICKUP_TRUCK_SMALL": //nicht
                                    vehicleclass = VehicleClass.PICKUP_TRUCK_SMALL;
                                    break;
                                case "PICKUP_TRUCK_STANDARD": //nicht
                                    vehicleclass = VehicleClass.PICKUP_TRUCK_STANDARD;
                                    break;
                                case "SPECIAL_PURPOSE_VEHICLE": //nicht
                                    vehicleclass = VehicleClass.SPECIAL_PURPOSE_VEHICLE;
                                    break;



                            }
                            // check for OS language, if "de" change comma seperation 
                            if (cultureInfo.TwoLetterISOLanguageName == "de")
                            {
                                decimal.TryParse(Data[3].Replace('.', ','), out enginesize);
                                decimal.TryParse(Data[9].Replace('.', ','), out  fuelconsumptioncombined);
                                decimal.TryParse(Data[11].Replace('.', ','), out  co2Emission);
                            }
                            else
                            {
                                decimal.TryParse(Data[3], out enginesize);
                                decimal.TryParse(Data[9], out  fuelconsumptioncombined);
                                decimal.TryParse(Data[11], out co2Emission);
                            }

                            int.TryParse(Data[4], out zylinder);

                            Transmission transmission = Transmission.NONE;
                            switch (Data[5])
                            {
                                //case "A":
                                //    transmission = Transmission.A_Automatic;
                                //    break;
                                //case "AM":
                                //    transmission = Transmission.AM_Automated_manual;
                                //    break;
                                //case "AS":
                                //    transmission = Transmission.AS_Automatic_with_select_shift;
                                //    break;
                                //case "AV":
                                //    transmission = Transmission.AV_Continuously_variable;
                                //    break;
                                case "M3":
                                    transmission = Transmission.M3;
                                    break;
                                case "M4":
                                    transmission = Transmission.M4;
                                    break;
                                case "M5":
                                    transmission = Transmission.M5;
                                    break;
                                case "M6":
                                    transmission = Transmission.M6;
                                    break;
                                case "M7":
                                    transmission = Transmission.M7;
                                    break;
                                case "M8":
                                    transmission = Transmission.M8;
                                    break;
                                case "M9":
                                    transmission = Transmission.M9;
                                    break;
                                case "M10":
                                    transmission = Transmission.M10;
                                    break;
                               

                            }

                            // AS,AV, AM, A with .StartsWith, because there are so many variants but only 4 enum categories
                            if (Data[5].StartsWith("AS")) transmission = Transmission.A_Automatic;
                            else if (Data[5].StartsWith("AM")) transmission = Transmission.AM_Automated_manual;
                            else if (Data[5].StartsWith("AV")) transmission = Transmission.AV_Continuously_variable;
                            else if (Data[5].StartsWith("A")) transmission = Transmission.A_Automatic;

                            FuelType fueltype = FuelType.None;
                            switch (Data[6]) // fueltype
                            {

                                case "X":
                                    fueltype = FuelType.X_Regular_gasoline;
                                    break;
                                case "Z":
                                    fueltype = FuelType.Z_Premium_gasoline;
                                    break;
                                case "D":
                                    fueltype = FuelType.D_Diesel;
                                    break;
                                case "E":
                                    fueltype = FuelType.E_Ethanol_E85;
                                    break;
                                case "N":
                                    fueltype = FuelType.N_Natural_gas;
                                    break;
                                
                            }
                            
                            

                            Car car = new Car(brand,
                                              model,
                                              vehicleclass,
                                              enginesize,
                                              zylinder,
                                              transmission,
                                              fueltype,
                                              fuelconsumptioncombined,
                                              co2Emission);

                            carlist.Add(car);
                        
                    }
                    
                }
            CarList outCarList = new CarList(carlist);

            return outCarList;
        }
            
            

            
        

    }
}
