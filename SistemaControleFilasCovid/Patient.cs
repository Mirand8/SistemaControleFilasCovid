using System;

namespace SistemaControleFilasCovid
{
    public class Patient
    {
        public int CPF { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool IsPreferencial => Age > 59;
        public bool IsEmergency { get; set; }
        public Report Report { get; set; }
        public Patient Next { get; set; }

        public Patient(int cpf, string name, DateTime birthDate,int age)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = age;
        }

        public Patient(int cpf, string name, DateTime birthDate, int age, bool isEmergency)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = age;
            IsEmergency = isEmergency;
        }

        public Patient (int cpf, string name, DateTime birthDate, int age, Report report)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = age;
            Report = report;
        } 

        public override string ToString()
        {
            return $"{CPF},{Name},{BirthDate:dd/MM/yyyy},{Age},{IsPreferencial},{IsEmergency};{Report}";
        }
    }
}