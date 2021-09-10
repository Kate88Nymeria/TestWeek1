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

                IHandler managerHandler = new ManagerHandler();
                IHandler operationalManagerHandler = new OperationalManagerHandler();
                IHandler ceoHandler = new CEOHandler();

                managerHandler.SetNext(operationalManagerHandler).SetNext(ceoHandler);

                bool rimborsoM = managerHandler.Handle(spesa);
                bool rimborsoOM = operationalManagerHandler.Handle(spesa);
                bool rimborsoC = ceoHandler.Handle(spesa);

                string approvazione = "APPROVATA";
                string livelloAppr = "";
                double importoRimborso = 0.0;

                if (rimborsoM || rimborsoOM || rimborsoC)
                {
                    if (rimborsoM)
                    {
                        livelloAppr = managerHandler.LivelloApprovazione;
                    }
                    if (rimborsoOM)
                    {
                        livelloAppr = operationalManagerHandler.LivelloApprovazione;
                    }
                    if (rimborsoC)
                    {
                        livelloAppr = ceoHandler.LivelloApprovazione;
                    }
                    

                    if (spesa.TipoCategoria == Categoria.Viaggio)
                    {
                        tipoRimborso = new Viaggio();
                        importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                    }
                    if (spesa.TipoCategoria == Categoria.Alloggio)
                    {
                        tipoRimborso = new Alloggio();
                        importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                    }
                    if (spesa.TipoCategoria == Categoria.Vitto)
                    {
                        tipoRimborso = new Vitto();
                        importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                    }
                    if (spesa.TipoCategoria == Categoria.Altro)
                    {
                        tipoRimborso = new Altro();
                        importoRimborso = tipoRimborso.CalcolaRimborso(spesa);
                    }
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
}
