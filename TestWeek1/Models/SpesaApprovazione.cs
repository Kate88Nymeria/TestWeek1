using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    public class SpesaApprovazione : Spesa
    {
        public string Approvazione { get; set; }
        public string LivelloApprovazione { get; set; }
        public double ImportoRimborsato { get; set; }

        public string StampaImportoRimborso(double importo)
        {
            string stringaImporto;

            if(importo == null)
            {
                stringaImporto = "-";
            }
            else
            {
                stringaImporto = $"{ImportoRimborsato}";
            }

            return stringaImporto;
        }

        public string StampaSpesaApprovazione()
        {
            return $"{DataSpesa.ToShortDateString()};{TipoCategoria};{Descrizione};{Approvazione.ToUpper()};{LivelloApprovazione};{StampaImportoRimborso(ImportoRimborsato)}";
        }

        public override string ToString()
        {
            return $"{DataSpesa.ToShortDateString()} - {TipoCategoria}: {Descrizione} - {Approvazione.ToUpper()} - {LivelloApprovazione} - Importo rimborsato{ImportoRimborsato} euro";
        }
    }
}
