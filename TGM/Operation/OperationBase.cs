using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGM.Operation
{
    public class OperationBase : IOperation
    {
        public OperationBase()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }

        public int Priorety { get; set; } = 0;

        public List<OperionException> Exceptions => new List<OperionException>();

        public long Duration => timer.ElapsedMilliseconds;
        private Stopwatch timer = new Stopwatch();

        public virtual bool Execute()
        {
            if (!timer.IsRunning)
                timer.Start();
            throw new NotImplementedException();
        }
    }
}
