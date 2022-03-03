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
            PreferentialLine = new PreferencialLine();
            CommumLine = new CommumLine();
        }

        public void GetInFirstLine()
        {
            Pacient newPacient = new (GenPassword);

            ++GenPassword;

            EntryLine.Entry(newPacient);
            newPacient.Password = GenPassword;
        }

        public void Register()
        {
            Pacient next;
            EntryLine.Show();
            if (!EntryLine.IsEmpty())
            {
                next = EntryLine.GetFirst();
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

                next = RegisterPacient(next, cpf, name, birthDate, DateTime.Now.Year - year);
                Console.WriteLine($"Novo paciente cadastrado: {next}");
                EntryLine.Pop();
            }
            else
            {
                next = null;
                Console.WriteLine("A fila de espera esta vazia!!");
                Console.ReadKey();
            }

            if (next != null)
            {
                if (next.IsPreferencial) PreferentialLine.Insert(next);

                else CommumLine.Insert(next);
            }
        }

        public void Sorting()
        {
            if (CommumLine.IsEmpty() && PreferentialLine.IsEmpty())
            {
                Console.WriteLine("Nenhum paciente registrado ainda!");
                Console.ReadKey();
            }
            else if (PreferentialLine.IsEmpty())
            {
                CommumLine.Show();
                Console.ReadKey();
                PreferentialLine.Count = 0;
            }
            else
            {
                if (PreferentialLine.Count < 2)
                {
                    
                    Console.ReadKey();
                    PreferentialLine.Count++;
                }
                else
                {
                    CommumLine.Show();
                    Console.ReadKey();
                    PreferentialLine.Count = 0;
                }
            }
        }

        public static void CreateReport(Pacient pacient)
        {
            Console.WriteLine(pacient);

            Console.Write("Temperatura: ");
            float temperature = float.Parse(Console.ReadLine());

            Console.Write("Pressao: ");
            int pressure = int.Parse(Console.ReadLine());

            Console.Write("Saturacao: ");
            int saturation = int.Parse(Console.ReadLine());

            Console.WriteLine("Inicio dos Sintomas=> ");
            Console.Write("Dia: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Mes: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Comorbidades=> ");

            int count = 0, stop = 0;
            string[] comorb = new string[20];
            while (stop == 0 && count < 20)
            {
                Console.Write("Adicionar comorbidade: ");
                comorb[count] = Console.ReadLine();
                count++;
                Console.WriteLine("Digite [1] para parar de adicionar.");
                stop = int.Parse(Console.ReadLine());
            }

            pacient.Report = new Report(temperature, pressure, saturation, new DateTime(year, month, day), comorb);

            Console.Write("Deseja arquivar o paciente? [0] sim [1] nao");
            int archive = int.Parse(Console.ReadLine());
            if (archive == 0)
            {

            }
        }

        public static Pacient RegisterPacient(Pacient pacient, int cpf, string name, DateTime birthDate, int age)
        {
            pacient.CPF = cpf;
            pacient.Name = name;
            pacient.BirthDate = birthDate;
            pacient.Age = age;

            return pacient;
        }
    }
}
