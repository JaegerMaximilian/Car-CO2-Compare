using System;
using CarCO2Comparer_BullshitButton_MVP.Main;
using System.Threading.Tasks;

namespace CarCO2Comparer_BullshitButton_MVP.Interfaces
{
    public interface IFilePersistor
    {
        event EventHandler<string> FilePathChanged;

        CarList CarListFromCSV(string filePath);
        string GetFilePath();
    }
}