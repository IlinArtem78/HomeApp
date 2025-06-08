using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeApp.ViewModel
{
    public class ResultsViewModel : INotifyPropertyChanged
    {
        private List<Cabinet> _cabinets;
        public List<Cabinet> Cabinets
        {
            get => _cabinets;
            set
            {
                _cabinets = value;
                OnPropertyChanged(nameof(Cabinets));
            }
        }

        public ResultsViewModel(List<Cabinet> cabinets)
        {
            Cabinets = cabinets;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
