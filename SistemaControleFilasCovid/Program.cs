using System;

namespace SistemaControleFilasCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PacientFlowControl pacientFlowControl = new ();

            int option;

            do
            {
                option = Menu();
                Console.Clear();
                switch (option)
                {
                    case 1:
                        
                        pacientFlowControl.GetInFirstLine();
                        Console.WriteLine("Um novo paciente entrou na fila de espera");
                        Console.WriteLine("Nova senha gerada: {0}", pacientFlowControl.GenPassword);
                        pacientFlowControl.EntryLine.Show();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("==== RECEPCAO ====");
                        pacientFlowControl.Reception();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("==== TRIAGEM ====");
                        pacientFlowControl.Sorting();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (option != 0);
        }

        private static int Menu()
        {
            Console.WriteLine("[1] - ENTRADA");
            Console.WriteLine("[2] - RECEPCAO");
            Console.WriteLine("[3] - TRIAGEM");
            Console.WriteLine("[4] - ");
            Console.WriteLine("[0] - ENCERRAR");
            Console.Write("Opcao: ");
            int option = int.Parse(Console.ReadLine());

            return option;
        }
    }
}
