using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DotNextSampleApp.Default;
using DotNextSampleApp.DotNextRZD.PublicApi.Model;

namespace DotNextRZD.Client.ViewModels
{
    public class TrainsViewModel : INotifyPropertyChanged
    {
        private readonly DotNextDataContext _dataContext;
        private IEnumerable<TrainModel> _trains;

        public IEnumerable<TrainModel> Trains
        {
            get { return _trains; }
            set
            {
                _trains = value;
                OnPropertyChanged();
            }
        }

        public TrainsViewModel()
        {
            _dataContext = new DotNextDataContext(new Uri("http://localhost:5000/"));
            LoadTrains();
        }

        public void LoadTrains()
        {
            _trains = _dataContext.Trains;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
