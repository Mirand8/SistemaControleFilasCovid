using System;

namespace SistemaControleFilasCovid
{
    public class Report
    {
        public float Temperature { get; set; }
        public string Pressure { get; set; }
        public int Saturation { get; set; }
        public DateTime OnsetSymptoms { get; set; }
        public string Symptoms { get; set; }
        public string Comorbidities { get; set; }
        public bool RiskCase => Comorbidities != null ;

        public bool Covid { get; set; }

        public Report(float temperature, string pressure, int saturation, DateTime onsetSymptoms, string comorbidities)
        {
            Temperature = temperature;
            Pressure = pressure;
            Saturation = saturation;
            OnsetSymptoms = onsetSymptoms;
            Comorbidities = comorbidities;
        }

        public Report(float temperature, string pressure, int saturation, DateTime onsetSymptoms, string comorbidities, string symptoms, bool covid)
        {
            Temperature = temperature;
            Pressure = pressure;
            Saturation = saturation;
            OnsetSymptoms = onsetSymptoms;
            Comorbidities = comorbidities;
            Covid = covid;
        }

        public override string ToString()
        {
            return $"{Temperature}, {Pressure}, {Saturation}, {OnsetSymptoms}, {Symptoms}, {Comorbidities}, {RiskCase}, {Covid}";
        }
    }
}