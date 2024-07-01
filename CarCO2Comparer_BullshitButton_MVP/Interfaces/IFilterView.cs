using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Filter;

namespace CarCO2Comparer_BullshitButton_MVP.Interfaces
{
    public interface IFilterView
    {
        #region Events
        event EventHandler<CarFilter> SaveClicked;
        event EventHandler ResetClicked;
        #endregion
        #region Members
        CarFilter CarFilter { get; set; }
        #endregion
        #region Methods
        void Show();
        #endregion
    }
}
