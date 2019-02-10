using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Init();
        public abstract void Init(TripLogEntry entry);
    }
}
