using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace XMProService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            if (System.Environment.UserInteractive)
            {
                if (args.Count() == 1)
                {
                    if (args[0] == "-i")
                        InstallService();

                    if (args[0] == "-u")
                        UninstallService();
                }
                return;
            }


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MyXMProService(args)
            };
            ServiceBase.Run(ServicesToRun);
        }
        private static void InstallService()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[]
            { Assembly.GetExecutingAssembly().Location });
            }
            catch (Exception ex)
            {
                //LogEvent.LogMe(ex.ToString());
            }
        }

        private static void UninstallService()
        {
            ManagedInstallerClass.InstallHelper(new string[]
            { "/u", Assembly.GetExecutingAssembly().Location });
        }
    }
}
