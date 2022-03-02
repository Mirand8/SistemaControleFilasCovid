using System;

namespace SistemaControleFilasCovid
{
    public class CommumLine
    {
        public Pacient Head { get; set; }
        public Pacient Tail{ get; set; }

        public CommumLine()
        {
            Head = null;
            Tail = null;
        }

        public void Insert(Pacient newPacient)
        {
            if (IsEmpty())
            {
                Head = Tail = newPacient;
            }
            else
            {
                Console.WriteLine("A fila comum esta cheia");
            }
        }

        public bool IsEmpty() => Head == null && Tail == null;
    }
}