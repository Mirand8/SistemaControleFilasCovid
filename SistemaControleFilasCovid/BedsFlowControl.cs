using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControleFilasCovid
{
    public class BedsFlowControl
    {
        public int BedsCount { get; set; }
        public List<Patient> WaitList { get; set; }
        public List<Patient> Hospitalized { get; set; }
        public bool AllBedsOccupied => Hospitalized.Count == BedsCount; 

        public BedsFlowControl()
        {
            WaitList = new ();
            Hospitalized = new ();
        }

        public bool Discharge(int cpf)
        {
            bool ok = true;
            if (Hospitalized.Count > 0) Hospitalized.Remove(Hospitalized.Find(pacient => pacient.CPF == cpf));
            else ok = false;
            return ok;
        }

        public void UpdateBedsCount(int newBedsCount)
        {
            if (newBedsCount < Hospitalized.Count)
            {
                Console.WriteLine("O novo numero de leitos eh menor que o numero de pessoas internadas!");
                Console.WriteLine("Voce precisa remover as pessoas dos leitos antes de fazer isso!");
            }
            else
            {
                Console.WriteLine("Você atualizou o numero de leitos, pessoas que estao na fila de espera serao alocadas para");
                Console.WriteLine("os novos leitos!");

                int count = 0;
                while (count < newBedsCount && count < WaitList.Count)
                {
                    Hospitalized.Add(WaitList.ElementAt(count));
                    WaitList.RemoveAt(count);
                    count++;
                }
            }
        }
    }
}
