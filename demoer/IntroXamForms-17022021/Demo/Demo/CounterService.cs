using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CounterService
    {
        public int GetCounter()
        {
            return Xamarin.Essentials.Preferences.Get("Counter", 0);
        }

        public void SaveCounter(int counter)
        {
            Xamarin.Essentials.Preferences.Set("Counter", counter);
        }
    }
}
