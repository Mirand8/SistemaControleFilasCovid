using System;

namespace SistemaControleFilasCovid
{
    public class Pacient
    {
        public int CPF { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool IsPreferencial => Age > 59;
        public bool IsEmergency { get; set; }
        public Report Report { get; set; }
        public Pacient Next { get; set; }

        public Pacient(int cpf, string name, DateTime birthDate,int age)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = age;
        }

        public Pacient(int cpf, string name, DateTime birthDate, int age, bool isEmergency)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = age;
            IsEmergency = isEmergency;
        }

        public Pacient (int cpf, string name, DateTime birthDate, int age, Report report)
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