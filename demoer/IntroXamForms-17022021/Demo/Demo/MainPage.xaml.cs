using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel m_mainViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = m_mainViewModel =  new MainViewModel(new CounterService());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SecondPage());
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            m_mainViewModel.Initialize();
        }
    }
}
