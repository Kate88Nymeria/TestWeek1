using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Handler;

namespace TestWeek1.Models
{
    public interface IRimborso
    {
        public double ImportoRimborsato { get; set; }

        public double CalcolaRimborso(Spesa spesa);
    }
}
