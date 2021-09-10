using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Handler;
using TestWeek1.Models;
using static TestWeek1.Models.Spesa;

namespace TestWeek1
{
    public class SpesaFactory
    {
        public double ImportoRimborsato { get; set; }

        public static List<Spesa> ListaSpese { get; set; }


        public static List<SpesaApprovazione> CreaSpeseApprovazione(List<Spesa> spese)
        {
            List<SpesaApprovazione> speseApprovazioni = new List<SpesaApprovazione>();
            foreach (Spesa spesa in spese)
            {
                IRimborso tipoRimborso;

                string approvazione = "APPROVATA";
                string livelloAppr = "";
                double importoRimborso;

                if (spesa.TipoCategoria == Categoria.Viaggio)
                {
                    tipoRimborso = new Viaggio();
                    livelloAppr = "Viaggio";
                    importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                }
                if (spesa.TipoCategoria == Categoria.Alloggio)
                {
                    tipoRimborso = new Alloggio();
                    livelloAppr = "Alloggio";
                    importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                }
                if (spesa.TipoCategoria == Categoria.Vitto)
                {
                    tipoRimborso = new Vitto();
                    livelloAppr = "Vitto";
                    importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                }
                if (spesa.TipoCategoria == Categoria.Altro)
                {
                    tipoRimborso = new Altro();
                    livelloAppr = "Altro";
                    importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                }
                else
                {
                    approvazione = "RESPINTA";
                    livelloAppr = "-";
                    importoRimborso = 0.0;
                }


                SpesaApprovazione speAppr = new SpesaApprovazione
                {
                    Approvazione = approvazione,
                    LivelloApprovazione = livelloAppr,
                    ImportoRimborsato = importoRimborso,
                    DataSpesa = spesa.DataSpesa,
                    Descrizione = spesa.Descrizione,
                    TipoCategoria = spesa.TipoCategoria,
                    Importo = spesa.Importo
                };

                speseApprovazioni.Add(speAppr);
            }
            //foreach (SpesaApprovazione sa in speseApprovazioni)
            //{
            //    Console.WriteLine(sa);
            //}

            return speseApprovazioni;
        }
    }


        //public static IHandler ApprovaSpesa()
        //{
        //    IHandler managerHandler = new ManagerHandler();
        //    IHandler operationalManagerHandler = new OperationalManagerHandler();
        //    IHandler ceoHandler = new CEOHandler();

        //    managerHandler.SetNext(operationalManagerHandler).SetNext(ceoHandler);

        //    return managerHandler;
        //}

        //public static double CalcolaRimborso(Spesa spesa)
        //{
        //    IHandler handler = ApprovaSpesa();

        //    if (handler.Approvazione)
        //    {
        //        if (spesa.TipoCategoria == Categoria.Viaggio)
        //        {
        //            return spesa.Importo + 50.0;
        //        }
        //        if (spesa.TipoCategoria == Categoria.Alloggio)
        //        {
        //            return spesa.Importo;
        //        }
        //        if (spesa.TipoCategoria == Categoria.Vitto)
        //        {
        //            return (spesa.Importo / 100.0) * 70.0;
        //        }
        //        if (spesa.TipoCategoria == Categoria.Altro)
        //        {
        //            return (spesa.Importo / 100.0) * 10;
        //        }
        //    }

        //    return 0.0;
        //}
}
