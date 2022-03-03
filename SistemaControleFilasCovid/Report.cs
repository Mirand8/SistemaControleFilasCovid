using System;

namespace SistemaControleFilasCovid
{
    public class Report
    {
        public float Temperature { get; set; }
        public int Pressure { get; set; }
        public int Saturation { get; set; }
        public DateTime OnsetSymptoms { get; set; }
        public string Comorbidities { get; set; }

        public Report(float temperature, int pressure, int saturation, DateTime onsetSymptoms, string[] comorbidities)
        {

        }
    }
}