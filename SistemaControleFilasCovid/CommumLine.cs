using System;

namespace SistemaControleFilasCovid
{
    public class CommumLine
    {
        public Pacient Head { get; set; }
        public Pacient Tail{ get; set; }
        public int Count { get; set; }

        public CommumLine()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Insert(Pacient newPacient)
        {
            if (IsEmpty()) Head = Tail = newPacient;

            else
            {
                Tail.Next = newPacient;
                Tail = newPacient;
            }
            Count++;
        }

        public Pacient GetFirst()
        {
            if (!IsEmpty())
            {
                Pacient first = Head;
                return first;
            }
            else return null;
        }

        public void Show()
        {
            Console.Write("FILA DE COMUM => ");
            Console.Write("[ ");
            if (!IsEmpty())
            {
                Pacient aux = Head;
                do
                {
                    if (aux.Next == null)
                    {
                        Console.Write(aux.Name);
                    }
                    else
                    {
                        Console.Write(aux.Name + ", ");
                    }
                    aux = aux.Next;
                } while (aux != null);
                Console.WriteLine(" ]");
            }
            else
            {
                Console.WriteLine("[ vazia ]");
            }
        }

        public bool IsEmpty() => Head == null && Tail == null;
    }
}