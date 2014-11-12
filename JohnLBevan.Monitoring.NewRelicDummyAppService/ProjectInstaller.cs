//Don't open in designer view - written as code only
using System;
using System.ServiceProcess;
namespace JohnLBevan.Monitoring.NewRelicDummyAppService
{
    /// <summary
    ///     Installer for the NewRelicDummyAppService.
    /// </summary>
    [System.ComponentModel.RunInstaller(true)]
    public class ProjectInstaller : System.Configuration.Install.Installer
    {
        //private System.ComponentModel.Container components;
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.serviceInstaller = new ServiceInstaller();
            this.serviceProcessInstaller = new ServiceProcessInstaller();
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Allows server to be associated with NewRelic application monitoring; requires that the NewRelic .net agent and server agents be installed."; //ServiceSettings.ServiceDescription;
            this.serviceInstaller.DisplayName = "NewRelicDummyService"; //ServiceSettings.ServiceDisplayName;
            this.serviceInstaller.ServiceName = "NewRelicDummyService"; //ServiceSettings.ServiceName;
            // 
            // serviceProcessInstaller
            // 
            //NB: these settings are easy to change after install, so leaving them hardcoded for the installer
            this.serviceProcessInstaller.Account = ServiceAccount.LocalSystem; //http://msdn.microsoft.com/en-us/library/system.serviceprocess.serviceaccount(v=vs.110).aspx
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // ServiceInstaller
            // 
            this.Installers.AddRange(
                new System.Configuration.Install.Installer[] 
                {
                    this.serviceProcessInstaller,
                    this.serviceInstaller
                }
            );

        }
    }
}
