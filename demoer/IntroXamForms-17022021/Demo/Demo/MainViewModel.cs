using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Demo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int m_counter;
        private readonly CounterService m_counterService;

        public MainViewModel(CounterService counterService)
        {
            IncrementCounterCommand = new Command(IncrementCounter);
            m_counterService = counterService;
        }

        public void Initialize()
        {
            Counter = m_counterService.GetCounter();
        }

        public ICommand IncrementCounterCommand { get; }

        public int Counter
        {
            get => m_counter;
            set
            {
                m_counter = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
            }
        }

        void IncrementCounter()
        {
            Counter++;
            m_counterService.SaveCounter(Counter);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
