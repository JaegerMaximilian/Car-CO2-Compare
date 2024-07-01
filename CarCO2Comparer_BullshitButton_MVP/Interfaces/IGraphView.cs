using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Filter;

namespace CarCO2Comparer_BullshitButton_MVP.Interfaces
{
    public interface IGraphView
    {
        #region Events
        event EventHandler JokeRequested;
        #endregion

        #region Members
        CarFilter carFilter { set; }
        #endregion

        #region Methods
        void Show();
        void ShowFilterSettings();
        void SetFilteredCars(List<Car> filteredCars);
        #endregion
    }
}
