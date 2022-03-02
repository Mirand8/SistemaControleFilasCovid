namespace SistemaControleFilasCovid
{
    public class Pacient
    {
        public int Password { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public Report[] Reports { get; set; }
        public Pacient Next { get; set; }

        public Pacient(string cpf, string name, string birthDate)
        {
            CPF = cpf;
            Name = name;
            BirthDate = birthDate;
        }
    }
}