using JohnLBevan.Monitoring.NewRelicDummyAppService;
using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        private Thread worker;
        private NewRelicDummyApp app = new NewRelicDummyApp();

        static void Main(string[] args)
        {
            new Program();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
        Program() {
            this.worker = new Thread(app.KeepNewRelicInterested);
            this.worker.Name = "NewRelicEntertainment";
            this.worker.IsBackground = false;
            app = new NewRelicDummyApp();
            this.worker.Start();        
        }
    }
}

