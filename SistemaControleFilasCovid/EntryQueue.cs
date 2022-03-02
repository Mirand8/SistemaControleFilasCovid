using System;

namespace SistemaControleFilasCovid
{
    public class EntryQueue
    {
        public Pacient Head { get; set; }
        public Pacient Tail { get; set; }
        public int Password { get; set; }

        public EntryQueue()
        {
            Head = null; 
            Tail = null;
        }

        public void Entry(Pacient newPacient)
        {
            if (IsEmpty())
            {
                Head = newPacient;
                Tail = newPacient;
            }
            else
            {
                Tail.Next = newPacient;
                Tail = newPacient;
            }

            newPacient.Password = Password;
        }

        // Normal out
        public void Out()
        {

        }

        // Emergency out
        public void Out(int password)
        {

        }

        private bool IsEmpty() => Head == null && Tail == null;
    }
}