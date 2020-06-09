using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemResourceReporterService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            LoggerInstance.InitLogger();
            try
            {
                if (args.Length > 0)
                {
                    using (var identity = WindowsIdentity.GetCurrent())
                    {
                        var principal = new WindowsPrincipal(identity);

                        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            return;
                        }
                    }

                    switch (args[0])
                    {
                        case "-install":
                        {
                            ManagedInstallerClass.InstallHelper(new string[]
                                {Assembly.GetExecutingAssembly().Location});
                            break;
                        }
                        case "-uninstall":
                        {
                            ManagedInstallerClass.InstallHelper(new string[]
                                {"/u", Assembly.GetExecutingAssembly().Location});
                            break;
                        }
                    }

                    return;
                }

                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain
                        chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new SystemInfoCollectorService()
                };
                ServiceBase.Run(ServicesToRun);

            }
            catch (Exception e)
            {
                LoggerInstance.Log.Error(e.Message);
            }
        }
    }
}
