using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DuplexServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class ProcessServiceImplement : ProcessServiceInterface
    {
        public void ProcessLongTask()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(40);
                OperationContext.Current.GetCallbackChannel<ProcessServiceCallback>().Progress(i);
            }
        }
    }
}
