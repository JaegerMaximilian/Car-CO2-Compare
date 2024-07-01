using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Filter;



namespace CarCO2Comparer_BullshitButton_MVP.Interfaces
{
    public interface IMainView
    {
        #region Events
        event EventHandler FilterViewRequested;
        event EventHandler GraphViewRequested;
        event EventHandler LoadFileRequested;
        event EventHandler JokeRequested;
        #endregion

        void LoadDataInList(List<Car> carlist);

        

        void ShowFilterSettings(CarFilter carFilter);


        void SetCurrentFile(string filePath);
    }
}
