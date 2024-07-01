using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP.Filter;

namespace CarCO2Comparer_BullshitButton_MVP.Graph
{
    public class GraphPresenter
    {
        #region Events
        public event EventHandler JokeRequested;
        #endregion

        #region Members
        private IGraphView _graphView;
        #endregion

        #region Constructor
        public GraphPresenter(IGraphView graphView)
        {
            _graphView = graphView;

            SetupLinks();
        }
        #endregion

        #region StartUp Methods
        private void SetupLinks()
        {
            // GraphView
            _graphView.JokeRequested += OnJokeRequested;
        }
        #endregion

        #region Methods
        public void Show()
        {
            _graphView.Show();
        }

        public void SetFilteredCars(List<Car> filteredCars)
        {
            _graphView.SetFilteredCars(filteredCars);
        }

        private void OnJokeRequested(object sender, EventArgs e)
        {
            JokeRequested?.Invoke(this, EventArgs.Empty);
        }

        public void ShowFilterSettings(CarFilter carFilter)
        {
            _graphView.carFilter = carFilter;
            _graphView.ShowFilterSettings();
        }
        #endregion
    }
}
