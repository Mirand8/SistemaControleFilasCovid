using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControleFilasCovid
{
    public class PacientFlowControl
    {
        public int GenPassword { get; set; }
        public PreferencialList Preferentials { get; set; }
        public CommonList Commons { get; set; }
        public List<Patient> Emergencies { get; set; }
        public int PrefCount { get; set; }
        public ArchiveController ArchiveController { get; set; }
        public BedsFlowControl BedsFlowControl { get; set; }

        public PacientFlowControl()
        {
            GenPassword = 0;
            Preferentials = new ();
            Commons = new();
            Emergencies = new();
            BedsFlowControl = new ();
        }

        public void CallNext() => GenPassword++;

        public void Register(bool isEmergency)
        {
            CallNext();
            Console.WriteLine("Senha atual: " + GenPassword);
            Console.WriteLine("\nREGISTRO: ");
            Console.Write("CPF: ");
            int cpf = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Data de Nascimento=> ");
            Console.Write("Dia: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Mes: ");
            int mounth = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int year = int.Parse(Console.ReadLine());
            DateTime birthDate = new (year, mounth, day);
            int age = DateTime.Now.Year - year;

            Patient newPacient;
            if (!isEmergency)
            {
                newPacient = new (cpf, name, birthDate, age);
                if (newPacient.IsPreferencial) Preferentials.Add(newPacient);

                else Commons.Add(newPacient);
            }
            else
            {
                newPacient = new (cpf, name, birthDate, age, isEmergency);
                Emergencies.Add(newPacient);
            }

            Console.WriteLine($"Novo paciente cadastrado: {newPacient}");
        }

        public void Exams(Patient pacient)
        {
            Console.WriteLine($"O paciente: {pacient.CPF}, {pacient.Name}");
            Console.WriteLine("[1] Não esta com covid");
            Console.WriteLine("[2] Tem a possibilidade de estar com covid");
            int option = int.Parse(Console.ReadLine());

            if (option == 1) ArchiveController.UploadToFile(pacient, ArchiveController.NoCovidPath);
            else
            {
                if (pacient.Report.Saturation > 90 || pacient.IsPreferencial || pacient.Report.Temperature > 37)
                {
                    Console.WriteLine("Parece que o paciente tem condições propicias a ser um caso emergencial!");
                    Console.WriteLine("Temperatura do paciente: " + pacient.Report.Temperature);
                    Console.WriteLine("Saturação do paciente: " + pacient.Report.Saturation);
                    Console.WriteLine("Paciente é idoso: " + pacient.IsPreferencial);
                }
                Console.WriteLine("Verificar prioridades: ");
                Console.WriteLine("[1] Paciente é assintomatico");
                Console.WriteLine("[2] Paciente tem risco");
                option = int.Parse(Console.ReadLine());

                if (option == 1) ArchiveController.UploadToFile(pacient, ArchiveController.QuarentinePath);
                else
                {
                    Console.WriteLine("Parece que é um caso grave!");
                    if (BedsFlowControl.AllBedsOccupied)
                    {
                        Console.WriteLine("Todos os leitos ja estao ocupado, enviando paciente para a fila de espera de leitos.");
                        Console.WriteLine("Enviando paciente para a fila de leitos de emergencia!");
                        BedsFlowControl.WaitList.Add(pacient);
                        ArchiveController.UploadToFile(pacient, ArchiveController.WaitingForBedPath);
                        Console.WriteLine($"{pacient.CPF} esta agora na fila de espera!");
                    }
                    else
                    {
                        Console.WriteLine("Que bom! Temos leitos desocupados!");
                        BedsFlowControl.Hospitalized.Add(pacient);
                        ArchiveController.UploadToFile(pacient, ArchiveController.HospitalizedPath);
                        Console.WriteLine($"{pacient.CPF} esta agora ocupando um lugar em um dos leitos!");
                    }
                }
                ArchiveController.UploadToFile(pacient, ArchiveController.HospitalizedPath);
            }
        }

        public void Exams(Patient pacient, bool isEmergency)
        {
            Console.WriteLine("Parece que o paciente tem condições propicias a ser um caso emergencial!");
            Console.WriteLine("Temperatura do paciente: " + pacient.Report.Temperature);
            Console.WriteLine("Saturação do paciente: " + pacient.Report.Saturation);
            Console.WriteLine("Paciente é idoso: " + pacient.IsPreferencial);
            Console.WriteLine("Parece que é um caso grave!");

            if (BedsFlowControl.AllBedsOccupied)
            {
                Console.WriteLine("Todos os leitos ja estao ocupado, enviando paciente para a fila de espera de leitos.");
                Console.WriteLine("Enviando paciente para a fila de leitos de emergencia!");
                BedsFlowControl.WaitList.Add(pacient);
                ArchiveController.UploadToFile(pacient, ArchiveController.WaitingForBedPath);
                Console.WriteLine($"{pacient.CPF} esta agora na fila de espera!");
            }
            else
            {
                Console.WriteLine("Que bom! Temos leitos desocupados!");
                BedsFlowControl.Hospitalized.Add(pacient);
                ArchiveController.UploadToFile(pacient, ArchiveController.HospitalizedPath);
                Console.WriteLine($"{pacient.CPF} esta agora ocupando um lugar em um dos leitos!");
            }
        }

        public Patient CallNextToAttend()
        {
            Patient next = null;

            if (Emergencies.Count == 0)
            {
                if (Commons.IsEmpty && Preferentials.IsEmpty)
                {
                    Console.WriteLine("\nNenhum registro ainda!\n");
                }
                else if (Preferentials.IsEmpty || PrefCount == 2)
                {
                    next = Commons.First();
                    Commons.RemoveFirst();
                    if (PrefCount == 2) PrefCount = 0;
                }
                else
                {
                    next = Preferentials.First();
                    Preferentials.RemoveFirst();
                    PrefCount++;
                }
            }
            else
            {
                next = Emergencies.First();
                Emergencies.RemoveAt(0);
            }
            return next;
        }

        public static Report CreateReport()
        {
            Console.WriteLine("==== ANAMNESE => ");
            Console.Write("\tTemperatura: ");
            float temperature = float.Parse(Console.ReadLine());

            Console.Write("\tPressao: ");
            string pressure = Console.ReadLine();

            Console.Write("\tSaturacao: ");
            int saturation = int.Parse(Console.ReadLine());

            Console.WriteLine("Inicio dos Sintomas=> ");
            Console.Write("\tDia: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("\tMes: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("\tAno: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("==== COVID => ");
            Console.Write("\tComorbidades: ");
            string comorb = Console.ReadLine();

            return new Report(temperature, pressure, saturation, new DateTime(year, month, day), comorb);
        }
    }
}
