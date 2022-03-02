using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControleFilasCovid
{
    public class PreferencialLine
    {
        public Pacient Head { get; set; }
        public Pacient Tail { get; set; }
        public int Count { get; set; }

        public PreferencialLine()
        {
            Head = Tail = null;
        }

        public void Insert(Pacient newPacient)
        {
            if (IsEmpty())
            {
                Head = Tail = newPacient;
            }
            else
            {
                Tail.Next = newPacient;
                Tail = newPacient;
            }
        }

        public bool IsEmpty() => Head == null && Tail == null;

        internal bool IsFull()
        {
            throw new NotImplementedException();
        }
    }
}
