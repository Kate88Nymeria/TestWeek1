using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Models;

namespace TestWeek1.Handler
{
    public class ManagerHandler : AbstractHandler
    {
        public override bool Handle(Spesa s)
        {
            if(s.Importo <= 400.0)
            {
                return true;
            }
            else
            {
                return base.Handle(s);
            }
        }
    }
}
