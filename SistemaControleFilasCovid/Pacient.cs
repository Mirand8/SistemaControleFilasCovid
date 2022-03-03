using System;

namespace SistemaControleFilasCovid
{
    public class Pacient
    {
        public int Password { get; set; }
        public int CPF { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool IsPreferencial => Age > 59;
        public Report Report { get; set; }
        public Pacient Next { get; set; }

        public Pacient(int cpf, string name, DateTime birthDate)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
            int now = DateTime.Now.Year;
            int birthYear = BirthDate.Year;
            Age = now - birthYear;
        }

        public Pacient (int password)
        {
            Password = password;
        } 

        public override string ToString()
        {
            return $"\n-=-=-=-=-=-=-=\n" +
                   $"CPF: {CPF}\n" +
                   $"Nome: {Name}\n" +
                   $"Data de Nascimento: {BirthDate:dd/MM/yyy}\n" +
                   $"Idade: {Age}\n" +
                   $"\n-=-=-=-=-=-=-=\n";
        }
    }
}