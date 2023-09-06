using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServiceInterface
{
    [ServiceContract(CallbackContract = typeof(ProcessServiceCallback))]
    public interface ProcessServiceInterface
    {
        [OperationContract(IsOneWay = true)]
        void ProcessLongTask();
    }

    public interface ProcessServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Progress(int percentageCompleted);
    }
}
