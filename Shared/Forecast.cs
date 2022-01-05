using System;

namespace BlazorApp.Shared
{
    public class Forecast
    {
        public string Date { get; set; }
        public int PayslipIncrease { get; set; }
        public string Feeling { get; set; }
        public int PayslipCount => 1083925 + (int)(PayslipIncrease);
    }
}
