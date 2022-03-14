using System;
using System.IO;

namespace SistemaControleFilasCovid
{
    public class ArchiveController
    {
        public const string NoCovidPath = @"C:\Users\Matheus Miranda\Desktop\HospitalCovidario\SemCovid\Pacientes.txt";

        public const string QuarentinePath = @"C:\Users\Matheus Miranda\Desktop\HospitalCovidario\Covid\Quarentena.txt";

        public const string HospitalizedPath = @"C:\Users\Matheus Miranda\Desktop\HospitalCovidario\Covid\Internacoes\EmLeitos.txt";
        public const string WaitingForBedPath = @"C:\Users\Matheus Miranda\Desktop\HospitalCovidario\Covid\Internacoes\EmFila.txt";

        public static void UploadToFile(Patient pacient, string filePath)
        {
            try
            {
                StreamReader reader = new(filePath);
                string data = reader.ReadToEnd();
                reader.Close();
                data += pacient;

                StreamWriter writer = new(filePath);
                writer.WriteLine(data);
                writer.Close();

                Console.Write($"Paciente {pacient.CPF} ");
                if (filePath == NoCovidPath) Console.WriteLine(" arquivado com sucesso!");
                else if (filePath == QuarentinePath) Console.WriteLine(" enviado ao arquivo de covid com sucesso");
                else if (filePath == HospitalizedPath) Console.WriteLine(" enviado a lista de internação com sucesso");
                else if (filePath == WaitingForBedPath) Console.WriteLine(" enviado a fila de espera para internaçao com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar no arquivo!");
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static string[] DownloadFile(string filePath)
        {

            string[] data = null;
            string line;
            try
            {
                StreamReader reader = new(filePath);
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                }
                count = 0;
                data = new string[count];
                while ((line = reader.ReadLine()) != null)
                {
                    data[count] = line;
                    count++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar no arquivo!");
                Console.WriteLine("Erro: " + ex.Message);
            }

            return data;
        }

        private static Report GetReport(string reportData)
        {
            string[] data = reportData.Split(',');

            float temperature = float.Parse(data[0]);
            string pressure = data[1];
            int saturation = int.Parse(data[2]);
            DateTime onsetSymptoms = DateTime.Parse(data[3]);
            string symptoms = data[4];
            string comorbidities = data[5];
            bool covid = bool.Parse(data[6]);

            return new Report(temperature, pressure, saturation, onsetSymptoms, symptoms, comorbidities, covid);
        }
    }
}
