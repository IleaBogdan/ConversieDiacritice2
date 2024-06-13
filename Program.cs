using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConversieDiacritice2
{
    internal class Program
    {
        // Main primeste un sir de stringuri ca si parametri
        static void Main(string[] args)
        {
            // verificam daca exista vreun argument 
            if (args.Length == 0)
            {
                Console.WriteLine("Lipseste numele fisierului!");
                return;
            }
            // indexam file_name cu numele fisierului 
            string file_name = args[0];
            // facem o copie pentru ca da
            File.Copy(file_name, file_name + ".bak", true);
            // citim in sirul de stringuri lines toate linile din fisier
            // cirirea se face cu encodarea 1252 (encodarea pt diacritice)
            string[] lines=File.ReadAllLines(file_name, 
                System.Text.Encoding.GetEncoding(1252));

            // creem un writer pt fisier cu encodarea UTF8 (pe asta o vede televizoru)
            using (StreamWriter sw = new StreamWriter(File.Open(file_name,
                FileMode.Create), Encoding.UTF8))
            {
                // pt fiecare string din line facem replaceu de diacritice
                foreach (string line in lines)
                {
                    string new_line = line;
                    //replace diacritics in new_line
                    new_line = new_line.Replace('þ', 'ţ'); //t mic
                    new_line = new_line.Replace('Þ', 'Ț'); //t mare
                    new_line = new_line.Replace('º', 'ş'); //s mic
                    new_line = new_line.Replace('ª', 'Ş'); //s mare
                    // scriem in fisier linia modificata
                    sw.WriteLine(new_line);
                }
            }
            Console.WriteLine("Program terminat cu succes!\r\nVizionare placuta!");
        }
    }
}
