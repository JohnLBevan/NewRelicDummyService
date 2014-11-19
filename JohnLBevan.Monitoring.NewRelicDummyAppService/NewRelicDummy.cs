using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace JohnLBevan.Monitoring.NewRelicDummyAppService
{
    class NewRelicDummyWinService : ServiceBase
    {
        private Thread worker;
        private NewRelicDummyApp app = new NewRelicDummyApp();

        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new NewRelicDummyWinService() };
            ServiceBase.Run(ServicesToRun);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceName = ServiceSettings.ServiceName;
        }

        protected override void OnStart(string[] args)
        {
            this.worker = new Thread(app.KeepNewRelicInterested);
            this.worker.Name = "NewRelicEntertainment";
            this.worker.IsBackground = false;
            app = new NewRelicDummyApp();
            this.worker.Start();            
        }
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            app.Stop();
            //process will now terminate once iteration completed.
        }
    }
}
