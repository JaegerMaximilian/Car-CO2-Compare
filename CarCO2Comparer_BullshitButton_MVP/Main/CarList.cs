using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Filter;

namespace CarCO2Comparer_BullshitButton_MVP
{
    public class CarList
    {
        private List<Car> carList = new List<Car>(); //public oder private??

        public CarList(List<Car> carlist)
        {
            this.carList = carlist;
        }
        public List<Car> ExportCarList()
        {
            return carList;
        }

       
        // Filter-Method, returns a List<Car>
        public List<Car> FilterCars(CarFilter cf) //cf for carfilter
        {
            List<Car> filteredCarList = new List<Car>();

            
            // IF NO FILTERS WERE APPLIED, RETURN WHOLE CARLIST
             if((cf.Brand[0] == "-" || cf.Brand[0] == String.Empty) && (cf.Brand[1] == "-" || cf.Brand[1] == String.Empty) 
                && (cf.Model[0] == "-" || cf.Model[0] == String.Empty) && (cf.Model[1] == "-" || cf.Model[1] == String.Empty)
                && cf.VehicleClass == Enums.VehicleClass.NONE && cf.EngineSizeMin == -1 && cf.EngineSizeMax == -1
                && cf.CylindersMin == -1 && cf.CylindersMax == -1 && cf.Transmission == Enums.Transmission.NONE 
                && cf.FuelType == Enums.FuelType.None && cf.FuelConsumptionMin == -1 && cf.FuelConsumptionMax == -1
                && cf.CO2EmissionsMin == -1 && cf.CO2EmissionsMax == -1)
            {
                filteredCarList = this.carList.ToList();
            } 
            else // IF FILTERES WERE APPLIED -> filter
            {
                foreach (var Car in this.carList)
                {
                    bool addToFilteredCars = false;

                    //made with Similiarities and Differences instead of single if, because the User could leave one maximum or minum open
                    // and the program has to check which one is open and search according to min/max settings

                    #region Similarities
                    // CHECK FOR SIMILARITIES, IF ONE OR MORE OF THEM APPLIES, SET addToFilteredCars=True!


                    // Brand (List with 2 elements)
                    if (((cf.Brand[0] != "-" && cf.Brand[0] != String.Empty) && Car.Brand.ToLower().StartsWith(cf.Brand[0].ToLower())) ||
                    ((cf.Brand[1] != "-" && cf.Brand[1] != String.Empty) && Car.Brand.ToLower().StartsWith(cf.Brand[1].ToLower()))) addToFilteredCars = true;



                    // Model (List with 2 elements)
                    if (((cf.Model[0] != "-" && cf.Model[0] != String.Empty) && Car.Model.ToLower().StartsWith(cf.Model[0].ToLower())) ||
                    ((cf.Model[1] != "-" && cf.Model[1] != String.Empty) && Car.Model.ToLower().StartsWith(cf.Model[1].ToLower()))) addToFilteredCars = true;



                    // Vehicle Class (enum)
                    if (cf.VehicleClass != Enums.VehicleClass.NONE && Car.vehicleClass == cf.VehicleClass) addToFilteredCars = true;


                    // Engine Size Min/Max
                    if ((cf.EngineSizeMin >= 0 && cf.EngineSizeMax >= 0) && (Car.EngineSize >= cf.EngineSizeMin && Car.EngineSize <= cf.EngineSizeMax)) addToFilteredCars = true;
                    if (cf.EngineSizeMin >= 0 && Car.EngineSize >= cf.EngineSizeMin) addToFilteredCars = true;
                    if (cf.EngineSizeMax >= 0 && Car.EngineSize <= cf.EngineSizeMax) addToFilteredCars = true;


                    // Cylinders Min/Max
                    if ((cf.CylindersMin >= 0 && cf.CylindersMax >= 0) && (Car.Zylinder >= cf.CylindersMin && Car.Zylinder <= cf.CylindersMax)) addToFilteredCars = true;
                    if (cf.CylindersMin >= 0 && Car.Zylinder >= cf.CylindersMin) addToFilteredCars = true;
                    if (cf.CylindersMax >= 0 && Car.Zylinder <= cf.CylindersMax) addToFilteredCars = true;

                    // Transmission (enum)

                    if (cf.Transmission != Enums.Transmission.NONE && Car.transmission == cf.Transmission) addToFilteredCars = true;
                    if (cf.Transmission != Enums.Transmission.NONE && cf.Transmission == Enums.Transmission.M_All && (Car.transmission == Enums.Transmission.M3 ||
                        Car.transmission == Enums.Transmission.M4 || Car.transmission == Enums.Transmission.M5 || Car.transmission == Enums.Transmission.M6 ||
                        Car.transmission == Enums.Transmission.M7 || Car.transmission == Enums.Transmission.M8 || Car.transmission == Enums.Transmission.M9 ||
                        Car.transmission == Enums.Transmission.M10)) addToFilteredCars = true;

                    // FuelType (enum)
                    if (cf.FuelType != Enums.FuelType.None && Car.fuelType == cf.FuelType) addToFilteredCars = true;

                    // FuelConsumption Min/Max
                    if ((cf.FuelConsumptionMin >= 0 && cf.FuelConsumptionMax >= 0) && (Car.FuelConsumptionCombined >= cf.FuelConsumptionMin && Car.FuelConsumptionCombined <= cf.FuelConsumptionMax)) addToFilteredCars = true;
                    if (cf.FuelConsumptionMin >= 0 && Car.FuelConsumptionCombined >= cf.FuelConsumptionMin) addToFilteredCars = true;
                    if (cf.FuelConsumptionMax >= 0 && Car.FuelConsumptionCombined <= cf.FuelConsumptionMax) addToFilteredCars = true;

                    // CO2 Emissions Min/Max
                    if ((cf.CO2EmissionsMin >= 0 && cf.CO2EmissionsMax >= 0) && (Car.CO2Emission >= cf.CO2EmissionsMin && Car.CO2Emission <= cf.CO2EmissionsMax)) addToFilteredCars = true;
                    if (cf.CO2EmissionsMin >= 0 && Car.CO2Emission >= cf.CO2EmissionsMin) addToFilteredCars = true;
                    if (cf.CO2EmissionsMax >= 0 && Car.CO2Emission <= cf.CO2EmissionsMax) addToFilteredCars = true;
                    #endregion

                    #region Differences
                    //CHECK IF ONE USED FILTER DOES NOT APPLY, IF SO, SET addToFilteredCars=false


                    // else if brand
                     if (cf.Brand[0] != "-" && cf.Brand[0] != String.Empty && cf.Brand[1] != "-" && cf.Brand[1] != String.Empty)
                    {
                        if ((!Car.Brand.ToLower().StartsWith(cf.Brand[0].ToLower())) &&
                        (!Car.Brand.ToLower().StartsWith(cf.Brand[1].ToLower()))) addToFilteredCars = false;


                        

                    }
                    else if (cf.Brand[0] != "-" && cf.Brand[0] != String.Empty)
                    {
                        if (!Car.Brand.ToLower().StartsWith(cf.Brand[0].ToLower())) addToFilteredCars = false;
                    }
                    
                    else if (cf.Brand[1] != "-" && cf.Brand[1] != String.Empty)
                    {
                        if (!Car.Brand.ToLower().StartsWith(cf.Brand[1].ToLower())) addToFilteredCars = false;
                    }


                    //else if Model
                     if (cf.Model[0] != "-" && cf.Model[0] != String.Empty && cf.Model[1] != "-" && cf.Model[1] != String.Empty)
                    {
                        if ((!Car.Model.ToLower().StartsWith(cf.Model[0].ToLower())) &&
                        (!Car.Model.ToLower().StartsWith(cf.Model[1].ToLower()))) addToFilteredCars = false;
                    }
                    // wenn model links voll und model rechts leer ist
                    else if (cf.Model[0] != "-" && cf.Model[0] != String.Empty && (cf.Model[1] == "-" || cf.Model[1] == String.Empty))
                    {
                        
                            if (Car.Brand.ToLower().StartsWith(cf.Brand[0].ToLower()))
                            {
                                if (!Car.Model.ToLower().StartsWith(cf.Model[0].ToLower())) addToFilteredCars = false;

                            } 

                    }
                   
                    //wenn model rechts voll und model links leer ist
                   else if (cf.Model[1] != "-" && cf.Model[1] != String.Empty && (cf.Model[0] == "-" || cf.Model[0] == String.Empty))
                    {
                        if (Car.Brand.ToLower().StartsWith(cf.Brand[1].ToLower()))
                        {
                            if (!Car.Model.ToLower().StartsWith(cf.Model[1].ToLower())) addToFilteredCars = false;
                        }
                    }

                    


                    // VehicleClass
                    if (cf.VehicleClass != Enums.VehicleClass.NONE && Car.vehicleClass != cf.VehicleClass) addToFilteredCars = false;

                    //EngineSize
                    if ((cf.EngineSizeMin >= 0 && cf.EngineSizeMax >= 0) && (Car.EngineSize < cf.EngineSizeMin || Car.EngineSize > cf.EngineSizeMax)) addToFilteredCars = false;
                    else if (cf.EngineSizeMin >= 0 && Car.EngineSize < cf.EngineSizeMin) addToFilteredCars = false;
                    else if (cf.EngineSizeMax >= 0 && Car.EngineSize > cf.EngineSizeMax) addToFilteredCars = false;

                    //Cylinders
                     if ((cf.CylindersMin >= 0 && cf.CylindersMax >= 0) && (Car.Zylinder < cf.CylindersMin || Car.Zylinder > cf.CylindersMax)) addToFilteredCars = false;
                    else if (cf.CylindersMin >= 0 && Car.Zylinder < cf.CylindersMin) addToFilteredCars = false;
                    else if (cf.CylindersMax >= 0 && Car.Zylinder > cf.CylindersMax) addToFilteredCars = false;

                    // Transmission
                    if (cf.Transmission != Enums.Transmission.NONE && cf.Transmission == Enums.Transmission.M_All &&
                        (Car.transmission != Enums.Transmission.M3 && Car.transmission != Enums.Transmission.M4 &&
                         Car.transmission != Enums.Transmission.M5 && Car.transmission != Enums.Transmission.M6 &&
                        Car.transmission != Enums.Transmission.M7 && Car.transmission != Enums.Transmission.M8 && Car.transmission != Enums.Transmission.M9 &&
                        Car.transmission != Enums.Transmission.M10)) addToFilteredCars = false;
                    else if (cf.Transmission != Enums.Transmission.NONE &&  cf.Transmission != Enums.Transmission.M_All &&
                        Car.transmission != cf.Transmission) addToFilteredCars = false;
                     

                    //FuelType
                     if (cf.FuelType != Enums.FuelType.None && Car.fuelType != cf.FuelType) addToFilteredCars = false;

                    //FuelConsumption
                     if ((cf.FuelConsumptionMin >= 0 && cf.FuelConsumptionMax >= 0) && (Car.FuelConsumptionCombined < cf.FuelConsumptionMin || Car.FuelConsumptionCombined > cf.FuelConsumptionMax)) addToFilteredCars = false;
                    else if (cf.FuelConsumptionMin >= 0 && Car.FuelConsumptionCombined < cf.FuelConsumptionMin) addToFilteredCars = false;
                    else if (cf.FuelConsumptionMax >= 0 && Car.FuelConsumptionCombined > cf.FuelConsumptionMax) addToFilteredCars = false;

                    //CO2 Emissions
                     if ((cf.CO2EmissionsMin >= 0 && cf.CO2EmissionsMax >= 0) && (Car.CO2Emission < cf.CO2EmissionsMin || Car.CO2Emission > cf.CO2EmissionsMax)) addToFilteredCars = false;
                    else if (cf.CO2EmissionsMin >= 0 && Car.CO2Emission < cf.CO2EmissionsMin) addToFilteredCars = false;
                    else if (cf.CO2EmissionsMax >= 0 && Car.CO2Emission > cf.CO2EmissionsMax) addToFilteredCars = false;
                    #endregion

                    // check if addToFilteredCars=true and if it is, add car to filteredCarList
                    if (addToFilteredCars == true)
                    {
                        filteredCarList.Add(Car);
                    }
                }
            }

           

           
            return filteredCarList;
        }

       
    }
}
