using System;

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

        public void Pop()
        {
            if (!IsEmpty())
            {
                if (Head.Next == null)
                {
                    Tail = null;
                }
                Head = Head.Next;
            }
            Count--;
        }

        public void Show()
        {
            Console.Write("FILA PREFERENCIAL => ");
            Console.Write("[ ");
            if (!IsEmpty())
            {
                Pacient aux = Head;
                do
                {
                    if (aux.Next == null)
                    {
                        Console.Write(aux.Name + " Idade: " + aux.Age);
                    }
                    else
                    {
                        Console.Write(aux.Name + " Idade: " + aux.Age + ", ");
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
