using HomeApp.API;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomeApp.ViewModel
{
    public class QuestionnaireViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ICommand NextCommand { get; }

        public QuestionnaireViewModel()
        {
            Questions = new ObservableCollection<Question>
        {
            new Question { Text = "Тип шкафа", Options = new List<string> { "Напольный", "Настенный", "19\"" } },
            new Question { Text = "Габариты", Options = new List<string> { "600x800x2000", "800x1000x2200" } }
        };

            NextCommand = new Command(async () => await GenerateReport());
        }

        private async Task GenerateReport()
        {
            // 1. Получаем выбранные ответы
            var selectedCabinetType = Questions[0].SelectedOption;
            var selectedSize = Questions[1].SelectedOption;

            // 2. Запрашиваем данные с Provento-Electro и ETM.ru
            var cabinet = await ProventoApi.GetCabinet(selectedCabinetType, selectedSize);
            var equipment = await EtmApi.GetEquipment();

            // 3. Переходим на страницу с таблицей
            await Application.Current.MainPage.Navigation.PushAsync(
                new ResultsPage(cabinet, equipment)
            );
        }
    }
}
