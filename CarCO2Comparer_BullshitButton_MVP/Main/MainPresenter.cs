using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;
using CarCO2Comparer_BullshitButton_MVP.Filter;
using CarCO2Comparer_BullshitButton_MVP.Graph;
using CarCO2Comparer_BullshitButton_MVP.Bullshit;



namespace CarCO2Comparer_BullshitButton_MVP.Main
{
    internal class MainPresenter
    {
        #region Members
        private IMainView _mainView;
        private IFilePersistor _filePersistor;
        private GraphPresenter _graphPresenter;
        private FilterPresenter _filterPresenter;
        private CarList _carList;
        private CarFilter _carFilter;



        #endregion

        #region Constructor
        public MainPresenter(IMainView mainView, IFilterView filterView,
                             IGraphView graphView, IFilePersistor filepersitor)
        {
            _mainView = mainView;
            _filePersistor = filepersitor;
            _filterPresenter = new FilterPresenter(filterView);
            _graphPresenter = new GraphPresenter(graphView);

            

            SetupLinks();
        }
        #endregion

        #region StartUp Methods
        private void SetupLinks()
        {
            // MainView
            _mainView.FilterViewRequested += OnFilterViewRequested;
            _mainView.GraphViewRequested += OnGraphViewRequested;
            _mainView.LoadFileRequested += OnLoadFileRequested;
            _mainView.JokeRequested += OnJokeRequested;

            // FilterPresenter
            _filterPresenter.MainPresenterGetFilterSettings += OnMainPresenterGetFilterSettings;
            _filterPresenter.MainPresenterResetFilter += OnMainPresenterResetFilter;

            // GraphPresenter
            _graphPresenter.JokeRequested += OnJokeRequested;

            // FilePersistor
            _filePersistor.FilePathChanged += OnFilePathChanged;

            

        }
        #endregion

        #region Methods

        private void OnFilterViewRequested(object sender, EventArgs e)
        {
            _filterPresenter.Show();
        }
        private void OnGraphViewRequested(object sender, EventArgs e)
        {
            _graphPresenter.Show();
        }


        
        // calls the GetFilePath-Method and CarListFromCSV in filePersistor and fills private member _carList with the Data from all the Cars
        private void OnLoadFileRequested(object sender, EventArgs e)
        {
           
            string filePath = _filePersistor.GetFilePath();

            _carList = _filePersistor.CarListFromCSV(filePath);

            _mainView.LoadDataInList(_carList.ExportCarList());


        }
       
        // Filters all elements with the CarFilter object stored originally in FilterPresenter and now also in MainPresenter
        private void OnMainPresenterGetFilterSettings(object sender, EventArgs e)
        {
            // check if count of carlist > 0, to apply filter
            if(_carList != null)
            {
                // calls the function FilterCars in FilterPresenter which returns the List of filtered Cars according to the CarFilter object
                List<Car> filteredCars = _filterPresenter.FilterCars(_carList);
                _graphPresenter.SetFilteredCars(filteredCars);

                // exports the FilteredCars List to the mainwindow 
                _mainView.LoadDataInList(filteredCars);
                _mainView.ShowFilterSettings(_filterPresenter.GetFilterSettings());
            }
        

            
            _carFilter = _filterPresenter.GetFilterSettings();
            _graphPresenter.ShowFilterSettings(_carFilter);

            
        }

        // Reset FilterSettings visually in the MainPresenter
        private void OnMainPresenterResetFilter(object sender, EventArgs e)
        {
            _mainView.LoadDataInList(_carList.ExportCarList());
            _mainView.ShowFilterSettings(new CarFilter());
        }

        // Shows new chuck norris joke
        private async void OnJokeRequested(object sender, EventArgs e)
        {
            string joke = await ChuckNorrisJokeDownloader.GetJsonString();
            BullshitView bullshitView = new BullshitView(joke);
            bullshitView.Show();
        }

        private void OnFilePathChanged(object sender, string filePath)
        {
            _mainView.SetCurrentFile(filePath);
        }
        #endregion
    }
}
