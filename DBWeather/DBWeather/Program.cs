using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            DAOWeather dAOWeather = new DAOWeather();
            dAOWeather.Show("reg2");
            dAOWeather.Show("reg2",-5);
            dAOWeather.ShowWeatherByLang("Polish");
        }
    }
}
