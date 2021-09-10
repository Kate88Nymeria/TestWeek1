using System;
using System.IO;
using static TestWeek1.SpesaFactory;
using TestWeek1.Handler;

namespace TestWeek1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = @"C:\Users\katia.caracciolo\Desktop\Projects\Week1\TestWeek1",
                Filter = "spese.txt"
            };

            fsw.EnableRaisingEvents = true;
            fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess |
                NotifyFilters.DirectoryName | NotifyFilters.FileName;

            fsw.Created += GestoreEvento.GestisciNuovoFile;

            Console.WriteLine("Inserisci il file 'spese.txt' oppure premi un tasto per terminare");
            Console.ReadKey();
        }
    }
}
