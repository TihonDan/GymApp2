using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamTimer.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, new PropertyChangedEventArgs(propertyName));
        }


        public TimerViewModel()
        {
            StartTimerCommand = new Command(OnStartTimerExecute);
            StartTime = TimeSpan.FromMinutes(2);
            Duration = StartTime.ToString();
        }

        private void OnStartTimerExecute()
        {
            Device.StartTimer(interval: TimeSpan.FromSeconds(1), callback: (() =>
            {
                if (StartTime.TotalSeconds > 0)
                {
                    StartTime = StartTime - TimeSpan.FromSeconds(1);
                    Duration = StartTime.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }));
        }

        public ICommand StartTimerCommand { get; set; }

        private string _duration;

        public TimeSpan StartTime { get; set; }
        public string Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

    }
}
