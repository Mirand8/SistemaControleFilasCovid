using System;

namespace SistemaControleFilasCovid
{
    public class PreferencialList
    {

        public Patient Head { get; set; }
        public Patient Tail { get; set; }
        public int Count { get; set; }
        public bool IsEmpty => Count == 0;

        public PreferencialList()
        {
            Head = Tail = null;
            Count = 0;
        }

        public void Add(Patient newPacient)
        {
            if (IsEmpty) Head = Tail = newPacient;

            else
            {
                Tail.Next = newPacient;
                Tail = newPacient;
            }
            Count++;
        }

        public Patient First()
        {
            if (!IsEmpty)
            {
                Patient first = Head;
                return first;
            }
            else return null;
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

        public void Remove(Patient pacient)
        {
            
        }

        public void Show()
        {
            Console.Write("FILA PREFERENCIAL => ");
            Console.Write("[ ");
            if (!IsEmpty)
            {
                Patient aux = Head;
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
    }
}