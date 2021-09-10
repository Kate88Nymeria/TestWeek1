using System;
using System.Collections.Generic;
using System.IO;
using TestWeek1.Models;
using static TestWeek1.SpesaFactory;

namespace TestWeek1
{
    public class GestoreEvento
    {
        
        public static void GestisciNuovoFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Gestione dell'evento {e.ChangeType} sul file {e.Name}");
            ListaSpese = ReadFile(e);
            WriteFile(ListaSpese);
        }

        private static void WriteFile(List<Spesa> elencoSpese)
        {
            string path = @"C:\Users\katia.caracciolo\Desktop\Projects\Week1\TestWeek1\spese_elaborate.txt";
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    Console.WriteLine($"Scrittura del file in corso");

                    List<SpesaApprovazione> speseAppr = CreaSpeseApprovazione(elencoSpese);

                    writer.WriteLine("Data;Categoria;Descrizione;Approvazione;LvlApprov;ImportoRimborsato");

                    foreach(SpesaApprovazione sa in speseAppr)
                    {
                        writer.WriteLine(sa.StampaSpesaApprovazione());
                    }

                    //foreach (Spesa s in elencoSpese) //stampa per controllo scrittura file
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"Error (IO): {ioe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static List<Spesa> ReadFile(FileSystemEventArgs e)
        {
            try
            {
                using(StreamReader reader = File.OpenText(e.FullPath))
                {
                    Console.WriteLine($"Lettura del file {e.Name} in corso");
                    List<Spesa> elencoSpese = new List<Spesa>();

                    string file = reader.ReadToEnd();
                    string[] righe = file.Split("\r\n");

                    for (int i = 1; i < righe.Length - 1; i++)
                    {
                        string[] dati = righe[i].Split(";");
                        DateTime.TryParse(dati[0], out DateTime data);
                        string categoria = dati[1];
                        string descrizione = dati[2];
                        double.TryParse(dati[3], out double importo);

                        Spesa spesa = new Spesa();
                        spesa.DataSpesa = data;
                        spesa.TipoCategoria = Spesa.SceltaCategoria(categoria);
                        spesa.Descrizione = descrizione;
                        spesa.Importo = importo;

                        elencoSpese.Add(spesa);
                    }
                    //foreach (Spesa s in elencoSpese) //stampa per controllo lettura file
                    //{
                    //    Console.WriteLine(s);
                    //}

                    return elencoSpese;
                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine($"Error (IO): {ioe.Message}");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}