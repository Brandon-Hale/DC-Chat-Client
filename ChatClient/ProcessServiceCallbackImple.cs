using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatClient;
using ServiceInterface;

namespace ChatClient1
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class ProcessServiceCallbackImple : ProcessServiceCallback
    {
        private LoginPage loginPage;

        public ProcessServiceCallbackImple(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }
        public void Progress(int percentageMainCompleted)
        {
            loginPage.Progress(percentageMainCompleted);
        }
    }
}
