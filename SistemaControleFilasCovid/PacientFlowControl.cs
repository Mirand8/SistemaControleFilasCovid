using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControleFilasCovid
{
    public class PacientFlowControl
    {
        public EntryLine EntryLine { get; set; }
        public int GenPassword { get; set; }
        public PreferencialLine PreferentialLine { get; set; }
        public CommumLine CommumLine { get; set; }

        public PacientFlowControl()
        {
            GenPassword = 0;
            EntryLine = new EntryLine();
        }

        public void GetInFirstLine()
        {
            Pacient newPacient = new (GenPassword);

            ++GenPassword;

            EntryLine.Entry(newPacient);
            newPacient.Password = GenPassword;
        }

        public void Reception()
        {
            if (!EntryLine.IsEmpty())
            {
                Pacient next = EntryLine.PullFirst();
                Console.WriteLine($"PACIENTE SENHA: {next.Password}");

                int cpf;
                string name;
                DateTime birthDate;

                Console.WriteLine("\nREGISTRO: ");
                Console.Write("CPF: ");
                cpf = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                name = Console.ReadLine();

                Console.Write("Data de Nascimento=> ");
                Console.Write("Dia: ");
                int day = int.Parse(Console.ReadLine());
                Console.Write("Mes: ");
                int mounth = int.Parse(Console.ReadLine());
                Console.Write("Ano: ");
                int year = int.Parse(Console.ReadLine());
                birthDate = new DateTime(year, mounth, day);

                next = RegisterPacient(next, cpf, name, birthDate);
                Console.WriteLine($"Novo paciente cadastrado: {next}");
                
                if (next.IsPreferencial() && !PreferentialLine.IsFull()) 
                    PreferentialLine.Insert(next);
                else CommumLine.Insert(next);

            }
            else
            {
                Console.WriteLine("A fila de espera esta vazia!!");
                Console.ReadKey();
            }
        }

        public static Pacient RegisterPacient(Pacient pacient, int cpf, string name, DateTime birthDate)
        {
            pacient.CPF = cpf;
            pacient.Name = name;
            pacient.BirthDate = birthDate;

            return pacient;
        }

        // triagem
        public void Sorting()
        {
            if (PreferentialLine.IsEmpty())
            {

            }
        }


    }
}
