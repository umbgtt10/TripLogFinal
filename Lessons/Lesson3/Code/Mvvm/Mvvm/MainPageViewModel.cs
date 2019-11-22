using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm
{
    public class Entry
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int counter = 0;
        private ObservableCollection<Entry> entries;
        public ObservableCollection<Entry> Entries
        {
            get
            {
                return entries;
            }
            set
            {
                entries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entries)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            private set
            {
                if (result != value)
                {
                    result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        private ICommand onButtonIncrementClickedCommand;
        public ICommand OnButtonIncrementClickedCommand
        {
            get
            {
                if (onButtonIncrementClickedCommand == null)
                {
                    onButtonIncrementClickedCommand = new Command(IncrementCommand);
                }

                return onButtonIncrementClickedCommand;
            }
        }

        private ICommand onButtonCustomIncrementClickedCommand;
        public ICommand OnButtonCustomIncrementClickedCommand
        {
            get
            {
                if (onButtonCustomIncrementClickedCommand == null)
                {
                    onButtonCustomIncrementClickedCommand = new Command<string>(IncrementCustomCommand);
                }

                return onButtonCustomIncrementClickedCommand;
            }
        }

        private ICommand onButtonResetClickedCommand;
        public ICommand OnButtonResetClickedCommand
        {
            get
            {
                if (onButtonResetClickedCommand == null)
                {
                    onButtonResetClickedCommand = new Command(ResetCommand);
                }

                return onButtonResetClickedCommand;
            }
        }

        private ICommand onButtonAddClickedCommand;
        public ICommand OnButtonAddClickedCommand
        {
            get
            {
                if (onButtonAddClickedCommand == null)
                {
                    onButtonAddClickedCommand = new Command(AddCommand);
                }

                return onButtonAddClickedCommand;
            }
        }

        private ICommand onButtonClearClickedCommand;
        public ICommand OnButtonClearClickedCommand
        {
            get
            {
                if (onButtonClearClickedCommand == null)
                {
                    onButtonClearClickedCommand = new Command(ClearCommand);
                }

                return onButtonClearClickedCommand;
            }
        }

        public MainPageViewModel()
        {
            Entries = new ObservableCollection<Entry>();
        }

        private void IncrementCommand()
        {
            counter++;
            UpdateResult();
        }

        private void IncrementCustomCommand(string args)
        {
            counter = counter + int.Parse(args);
            UpdateResult();
        }

        private void ResetCommand()
        {
            counter = 0;
            UpdateResult();
        }

        private void AddCommand()
        {
            var newEntry = new Entry()
            {
                Value1 = counter,
                Value2 = counter + 1
            };

            Entries.Add(newEntry);
        }

        private void ClearCommand()
        {
            Entries.Clear();
        }

        private void UpdateResult()
        {
            Result = counter.ToString();
        }
    }
}
