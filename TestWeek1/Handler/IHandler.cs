using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Models;

namespace TestWeek1.Handler
{
    public interface IHandler
    {
        public Spesa SpesaDaApprovare { get; set; }
        public bool Approvazione { get; }

        IHandler SetNext(IHandler handler);
        bool Handle(Spesa s);
    }
}
