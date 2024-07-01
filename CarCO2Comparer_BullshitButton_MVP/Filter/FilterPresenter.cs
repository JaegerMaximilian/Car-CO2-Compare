using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP;

namespace CarCO2Comparer_BullshitButton_MVP.Filter
{
    internal class FilterPresenter
    {
        #region Events
        public event EventHandler MainPresenterGetFilterSettings;
        public event EventHandler MainPresenterResetFilter;
        #endregion

        #region Members
        private IFilterView _filterView;
        private CarFilter _carfilter;
        #endregion

        #region Constructor
        public FilterPresenter(IFilterView filterView)
        {
            _filterView = filterView;

            SetupLinks();
        }
        #endregion

        #region StartUp Methods
        private void SetupLinks()
        {
            _filterView.SaveClicked += OnSaveClicked;
            _filterView.ResetClicked += OnResetClicked;
        }
        #endregion

        #region Methods
        public void Show()
        {
            _filterView.Show();
        }

        // rerouts CarFilterClass from filterView to carlist.FilterCars and sends it to MainPresenter
        public List<Car> FilterCars(CarList carlist)
        {
            List<Car> filteredCars = carlist.FilterCars(_carfilter);
            return filteredCars;
        }

        // returns filterSettings that the User chose for MainView and GraphView
        public CarFilter GetFilterSettings()
        {
            return _carfilter;
        }

        // raises event to start filtering and showing the FilterSettings in MainView
        private void OnSaveClicked(object sender, CarFilter carfilter)
        {
            _carfilter = carfilter;
            MainPresenterGetFilterSettings?.Invoke(sender, EventArgs.Empty);
           
        }

        // raises the event that resets the filter settings to its default values and updates FilterSettings-Box in Main-View
        private void OnResetClicked(object sender, EventArgs e)
        {
            MainPresenterResetFilter?.Invoke(sender, e);
        }
        #endregion

    }
}
