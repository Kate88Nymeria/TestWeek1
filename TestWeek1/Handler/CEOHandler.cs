using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Models;

namespace TestWeek1.Handler
{
    public class CEOHandler : AbstractHandler
    {
        public override bool Handle(Spesa s)
        {
            if (s.Importo > 1000.0 && s.Importo <= 2500)
            {
                LivelloApprovazione = "CEO";
                return true;
            }
            
            return base.Handle(s);
        }
    }
}
