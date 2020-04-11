using System;

namespace WebApiTest.Domain
{
    public class Weather
    {    
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }

        public string City { get; set; }        
    }
}
