namespace SystemResourceReporterService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PerformanceCollectorInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SystemPerformanceCollector = new System.ServiceProcess.ServiceInstaller();
            // 
            // PerformanceCollectorInstaller
            // 
            this.PerformanceCollectorInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.PerformanceCollectorInstaller.Password = null;
            this.PerformanceCollectorInstaller.Username = null;
            // 
            // SystemPerformanceCollector
            // 
            this.SystemPerformanceCollector.ServiceName = "SystemPerformanceCollectorService";
            this.SystemPerformanceCollector.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PerformanceCollectorInstaller,
            this.SystemPerformanceCollector});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller SystemPerformanceCollector;
        public System.ServiceProcess.ServiceProcessInstaller PerformanceCollectorInstaller;
    }
}