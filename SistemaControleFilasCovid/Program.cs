using System;

namespace SistemaControleFilasCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PacientFlowControl pacientFlowControl = new ();

            int menuOption;

            do
            {
                menuOption = Menu();
                Console.Clear();
                switch (menuOption)
                {
                    case 1:
                        Console.WriteLine("==== RECEPCAO ====");
                        pacientFlowControl.Register(false);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Patient next = pacientFlowControl.CallNextToAttend();
                        if (next == null)
                        {
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        } 
                            
                        Console.WriteLine("==== EXAMES ====");
                        Console.Write("=> PROXIMO DA FILA DE EXAMES: \n");
                        Console.ReadKey();
                        Console.WriteLine("Paciente: \n " + next);
                        next.Report = PacientFlowControl.CreateReport();
                        Console.WriteLine("Relatorio do paciente {0} criado", next.Name);
                        Console.WriteLine(next.Report);
                        Console.WriteLine("Teste covid: ");
                        pacientFlowControl.Exams(next);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        int casesOption;
                        do
                        {
                            Console.WriteLine("==== GERENCIAMENTO DE CASOS ====");
                            Console.WriteLine("[1] Emergencias");
                            Console.WriteLine("[2] Casos em querentena salvos");
                            Console.WriteLine("[3] Casos sem covid salvos");
                            Console.WriteLine("[0] Sair");
                            casesOption = int.Parse(Console.ReadLine());
                            switch (casesOption)
                            {
                                case 1:
                                    int emerOption;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("==== GERENCIAMENTO DE EMERGENCIAS E LEITOS ====");
                                        Console.WriteLine("[1] Mostrar fila de espera");
                                        Console.WriteLine("[2] Mostrar numero de leitos");
                                        Console.WriteLine("[3] Mudar numero de leitos");
                                        Console.WriteLine("[4] Mostrar pacientes em leitos");
                                        Console.WriteLine("[5] Dar alta em leito");
                                        Console.WriteLine("[0] Sair");
                                        emerOption = int.Parse(Console.ReadLine());
                                        switch (emerOption)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("==== FILA DE ESPERA ====");
                                                Console.WriteLine("LISTA DE ESPERA:");
                                                if (pacientFlowControl.BedsFlowControl.WaitList.Count != 0) 
                                                    pacientFlowControl.BedsFlowControl.WaitList.ForEach(pacients => Console.WriteLine(pacients));
                                                Console.ReadKey();
                                                break;

                                            case 2:
                                                Console.WriteLine("Numero de leitos: " + pacientFlowControl.BedsFlowControl.BedsCount);
                                                Console.ReadKey();
                                                break;

                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Novo numero de leitos: ");
                                                int bedsCount = int.Parse(Console.ReadLine());
                                                pacientFlowControl.BedsFlowControl.UpdateBedsCount(bedsCount);
                                                Console.WriteLine("Numero de leitos alterado!");
                                                Console.ReadKey();
                                                break;

                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("LISTA DE INTERNADOS:");
                                                pacientFlowControl.BedsFlowControl.Hospitalized.ForEach(pacients => Console.WriteLine(pacients));
                                                Console.ReadKey();
                                                break;

                                            case 5:
                                                Console.Clear();
                                                Console.WriteLine("Digite o CPF do paciente que vai receber alta: ");
                                                int cpf = int.Parse(Console.ReadLine());
                                                bool ok = pacientFlowControl.BedsFlowControl.Discharge(cpf);
                                                if (ok)
                                                {
                                                    Console.WriteLine("Parabéns! Paciente de CPF: {0} recebeu alta!! =)", cpf);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Não foi possivel dar alta no paciente!");
                                                }
                                                Console.ReadKey();
                                                break;

                                            case 0:
                                                Console.Clear();
                                                break;
                                        }
                                    } while (emerOption > 0);
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("LISTA DE CASOS EM QUARENTENA: ");
                                    string[] quarentineData = ArchiveController.DownloadFile(ArchiveController.QuarentinePath);

                                    if (quarentineData != null) foreach (string pacient in quarentineData)  Console.WriteLine(pacient);

                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("LISTA DE CASOS SEM COVID: ");
                                    string[] noCovidData = ArchiveController.DownloadFile(ArchiveController.NoCovidPath);

                                    if (noCovidData != null) foreach (string pacient in noCovidData) Console.WriteLine(pacient);

                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                            }
                        } while (casesOption > 0);
                        break;

                    case 4:
                        Console.WriteLine("==== AREA DE EMERGENCIA ====");
                        pacientFlowControl.Register(true);

                        Patient emergencyP = pacientFlowControl.CallNextToAttend();
                        if (emergencyP == null)
                        {
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        Console.WriteLine("==== EXAMES ====");
                        Console.WriteLine("Paciente: \n " + emergencyP);
                        emergencyP.Report = PacientFlowControl.CreateReport();
                        Console.WriteLine("Relatorio do paciente {0} criado", emergencyP.Name);
                        Console.WriteLine(emergencyP.Report);
                        pacientFlowControl.Exams(emergencyP, emergencyP.IsEmergency);

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (menuOption > 0);
        }

        private static int Menu()
        {
            Console.WriteLine("[1] - RECEPCAO");
            Console.WriteLine("[2] - TRIAGEM");
            Console.WriteLine("[3] - GERENCIAR CASOS");
            Console.WriteLine("[4] - RECEPCAO EMERGENTE");
            Console.WriteLine("[0] - ENCERRAR");
            Console.Write("Opcao: ");
            int option = int.Parse(Console.ReadLine());

            return option;
        }
    }
}
