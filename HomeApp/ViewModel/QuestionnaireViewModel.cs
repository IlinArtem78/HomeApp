using HomeApp.API;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using HomeApp.Pages; 

namespace HomeApp.ViewModel
{
    public class QuestionnaireViewModel : INotifyPropertyChanged
    {
        public List<string> CabinetTypes { get; } = new List<string> { "Настенный", "Напольный", "19\"" };
        public List<string> Sizes { get; } = new List<string> { "600x800x2000", "800x1000x2200" };

        private string _selectedType;
        public string SelectedType
        {
            get => _selectedType;
            set { _selectedType = value; OnPropertyChanged(); }
        }

        private string _selectedSize;
        public string SelectedSize
        {
            get => _selectedSize;
            set { _selectedSize = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand { get; }

        public QuestionnaireViewModel()
        {
            SearchCommand = new Command(async () => await SearchCabinetsAsync());
        }

        private async Task SearchCabinetsAsync()
        {
            var allCabinets = await ExcelLoaderService.LoadCabinetsAsync();

            // Фильтрация по выбранным параметрам
            var filteredCabinets = allCabinets
                .Where(c => c.Type == SelectedType && c.Size.Contains(SelectedSize))
                .ToList();

            // Переход на страницу с результатами
            await Application.Current.MainPage.Navigation.PushAsync(
                new ResultPages(filteredCabinets)
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
