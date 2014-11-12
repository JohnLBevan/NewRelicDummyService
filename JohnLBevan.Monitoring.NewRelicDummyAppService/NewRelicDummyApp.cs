using System;
using System.Diagnostics;
using System.Data.SqlClient;

namespace JohnLBevan.Monitoring.NewRelicDummyAppService
{
    class NewRelicDummyApp
    {
        private readonly object syncroot = new object();
        private bool running = false;
        public bool Running 
        {
            get { return this.Running; }
        }


        public void KeepNewRelicInterested()
        {
            lock (this.syncroot)
            {
                this.running = true;
            }
            int sleepTime = ServiceSettings.SleepTime;
            while (running)
            {
                System.Threading.Thread.Sleep(sleepTime);
                PingDBs();                
            }
        }
        public void Stop()
        {
            lock (this.syncroot)
            {
                this.running = false;
            }
        }

        /// <summary>
        /// Sends a command to each DB (connection string) to ensure there's something interesting for NewRelic
        /// </summary>
        private void PingDBs()
        {
            //works for multiple dbs rather than just one in case we want NewRelic to infer additional connection information
            //most use cases we'll just use one
            foreach (string connectionString in ServiceSettings.ConnectionStrings)
            {
                //wrap call in error handling so we remain in the parent's loop no matter what / so that we still ping additional dbs as needed
                try { DoSomethingOnDB(connectionString); } //call it once before the loop without error handling so we'll be told if connection string's invalid
                catch (Exception e) { Debug.WriteLine(e.ToString()); }
            }
        }

        //perform some action which will create monitoring data for NewRelic
        const string SqlTestCommand = "select getutcdate() CurrentTime"; //currently must return a single datetime value to be compatible with execution code
        private void DoSomethingOnDB(string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlTestCommand, con))
                {
                    DateTime currentTime = DateTime.Parse(cmd.ExecuteScalar().ToString());
                }
            }
        }

    }
}
