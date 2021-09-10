using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek1.Models;

namespace TestWeek1.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public bool Approvazione { get { return Handle(SpesaDaApprovare); } }
        public Spesa SpesaDaApprovare { get; set; }
        public string LivelloApprovazione { get; set; }

        public virtual bool Handle(Spesa s)
        {
            if(_nextHandler != null)
            {
                return _nextHandler.Handle(s);
            }
            return false;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}
