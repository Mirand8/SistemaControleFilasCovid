using System;

namespace SistemaControleFilasCovid
{
    public class CommonList
    {
        public Pacient Head { get; set; }
        public Pacient Tail { get; set; }
        public int Count { get; set; }
        public bool IsEmpty => Count == 0;

        public CommonList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public Pacient First()
        {
            if (!IsEmpty)
            {
                Pacient first = Head;
                return first;
            }
            else return null;
        }

        public void Add(Pacient newPacient)
        {
            if (IsEmpty) Head = Tail = newPacient;

            else
            {
                Tail.Next = newPacient;
                Tail = newPacient;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (!IsEmpty)
            {
                if (Head.Next == null)
                {
                    Tail = null;
                }
                Head = Head.Next;
            }
            Count--;
        }

        public void Remove(Pacient pacient)
        {

        }

        public void Show()
        {
            Console.Write("FILA DE COMUM => ");
            Console.Write("[ ");
            if (!IsEmpty)
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
    }
}