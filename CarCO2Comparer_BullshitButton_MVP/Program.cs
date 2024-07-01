using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarCO2Comparer_BullshitButton_MVP.Graph;
using CarCO2Comparer_BullshitButton_MVP.FileHandler;
using CarCO2Comparer_BullshitButton_MVP.Filter;
using CarCO2Comparer_BullshitButton_MVP.Main;
using CarCO2Comparer_BullshitButton_MVP.Interfaces;

namespace CarCO2Comparer_BullshitButton_MVP
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainView mainView = new MainView();
            IFilterView filterView = new FilterView();
            IGraphView graphView = new GraphView();
            IFilePersistor filepersistor = new FilePersistor();

            MainPresenter presenter = new MainPresenter(mainView, filterView, graphView, filepersistor);

            Application.Run(mainView);

            
        }
    }
}
