using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TGM.Operation
{
    public interface IOperation
    {
        long Duration { get; }
        Guid ID { get; }
        int Priorety { set; get; }
        List<OperionException> Exceptions { get; }
        bool Execute();
    }

    public class OperionException : Exception
    {

    }
}
