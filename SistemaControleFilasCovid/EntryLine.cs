using System;

namespace SistemaControleFilasCovid
{
    public class EntryLine
    {
        public Pacient Head { get; set; }
        public Pacient Tail { get; set; }

        public EntryLine()
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
        }

        public Pacient PullFirst()
        {
            if (!IsEmpty())
            {
                Pacient first = Head;
                Pop();
                return first;
            }
            else return null;
        }

        public void Show()
        {
            Console.Write("FILA DE ESPERA => ");
            Console.Write("[ ");
            Pacient aux = Head;
            do
            {
                if (aux.Next == null)
                {
                    Console.Write(aux.Password);
                }
                else
                {
                    Console.Write(aux.Password + ", ");
                }
                aux = aux.Next;
            } while (aux != null);
            
            Console.Write(" ]");
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
        }

        public void Out(int password)
        {
            
        }

        public bool IsEmpty() => Head == null && Tail == null;

    }
}