using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    public class Viaggio : IRimborso
    {
        public double ImportoRimborsato { get ; set ; }

        public double CalcolaRimborso(Spesa spesa)
        {
            return spesa.Importo + 50.0;
        }
    }
}
